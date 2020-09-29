using System;
using System.Threading.Tasks;
using NHibernate;
using NServiceBus;
using NServiceBus.Testing;
using NServiceBus.UnitOfWork;
using StructureMap;

namespace ReportingModule.SystemTests.Nsb7.Configuration
{
	public static class Endpoint
	{
		// Use to make an arrangment on an endpoint, not using a handler.
		public static void Arrange(
			IContainer container,
			Action<IContainer> arrange)
		{
			using (IContainer nestedContainer = container.GetNestedContainer())
			{
				var unitOfWork = nestedContainer.GetInstance<IManageUnitsOfWork>();
				unitOfWork.Begin();
				arrange(nestedContainer);
				unitOfWork.End();
			}
		}

		public static void ArrangeOnSqlSession(
			IContainer container,
			Action<ISession> arrange)
		{
			using (IContainer nestedContainer = container.GetNestedContainer())
			{
				var unitOfWork = nestedContainer.GetInstance<IManageUnitsOfWork>();
				unitOfWork.Begin();
				var session = nestedContainer.GetInstance<ISession>();
				arrange(session);
				unitOfWork.End();
			}
		}

		public static T Arrange<T>(
			IContainer container,
			Func<IContainer, T> arrange)
		{
			using (IContainer nestedContainer = container.GetNestedContainer())
			{
				var unitOfWork = nestedContainer.GetInstance<IManageUnitsOfWork>();
				unitOfWork.Begin();
				T result = arrange(nestedContainer);
				unitOfWork.End();
				return result;
			}
		}

		public static T ArrangeOnSqlSession<T>(
			IContainer container,
			Func<ISession, T> arrange)
		{
			return Arrange(container,
				c =>
				{
					var session = c.GetInstance<ISession>();
					return arrange(session);
				});
		}

		public static async Task<TestableMessageHandlerContext> Arrange<THandler>(
			IContainer container,
			Func<THandler, TestableMessageHandlerContext, Task> act)
		{
			return await Execute(container, act);
		}

		private static async Task<TestableMessageHandlerContext> Execute<THandler>(
			IContainer container,
			Func<THandler, TestableMessageHandlerContext, Task> act)
		{
			using (var nestedContainer = container.GetNestedContainer())
			{
				var messageContext = new TestableMessageHandlerContext();
				var nc = nestedContainer;
				using (var session = nc.GetInstance<ISession>())
				{
					var tx = session.BeginTransaction();
					try
					{
						var handler = nc.GetInstance<THandler>();
						await act(handler, messageContext).ConfigureAwait(false);
						tx.Commit();
					}
					catch
					{
						tx?.Rollback();
						throw;
					}
				}
				return messageContext;
			}
		}

		public static async Task<Exception> ActRaisesException<THandler>(
			IContainer container,
			Func<THandler, TestableMessageHandlerContext, Task> act)
		{
			try
			{
				await Act(container, act);
			}
			catch (Exception e)
			{
				return e;
			}
			NUnit.Framework.Assert.Fail("No exception was raised.");
			return null;
		}

		public static T Act<T>(
			IContainer container,
			Func<IContainer, T> act)
		{
			using (IContainer nestedContainer = container.GetNestedContainer())
			{
				var unitOfWork = nestedContainer.GetInstance<IManageUnitsOfWork>();
				unitOfWork.Begin();
				T result = act(nestedContainer);
				unitOfWork.End();
				return result;
			}
		}

		public static T ActOnSqlSession<T>(
			IContainer container,
			Func<ISession, T> act)
		{
			return Act(container,
					   c =>
					   {
						   var session = c.GetInstance<ISession>();
						   return act(session);
					   });
		}

		public static void ActOnSqlSession(
			IContainer container,
			Action<ISession> act)
		{
			Act(container,
				c =>
				{
					var session = c.GetInstance<ISession>();
					act(session);
				});
		}

		public static Exception ActOnSqlSessionRaisesException(
			IContainer container,
			Action<ISession> act)
		{
			try
			{
				ActOnSqlSession(container, act);
			}
			catch (Exception e)
			{
				return e;
			}
			NUnit.Framework.Assert.Fail("No exception was raised.");
			return null;
		}


		public static void Act(
			IContainer container,
			Action<IContainer> act)
		{
			using (IContainer nestedContainer = container.GetNestedContainer())
			{
				var unitOfWork = nestedContainer.GetInstance<IManageUnitsOfWork>();
				unitOfWork.Begin();
				act(nestedContainer);
				unitOfWork.End();
			}
		}

		// Use to act with a handler on an endpoint
		public static async Task<TestableMessageHandlerContext> Act<THandler>(
			IContainer container,
			Func<THandler, TestableMessageHandlerContext, Task> act)
		{
			return await Execute(container, act);
		}

		public static void AssertThat(
			IContainer container,
			Action<IContainer> assertions)
		{
			using (IContainer nestedContainer = container.GetNestedContainer())
			{
				assertions(nestedContainer);
			}
		}

		public static void AssertOnSqlSessionThat(
			IContainer container,
			Action<ISession> assertions)
		{
			AssertThat(container,
				c =>
				{
					var session = c.GetInstance<ISession>();
					assertions(session);
				});
		}

		public static void AssertThat(
			IContainer container,
			Action<ISession> assertions)
		{
			AssertThat(container,
				c =>
				{
					var session = c.GetInstance<ISession>();
					assertions(session);
				});
		}
	}

	public static class MessageHandlerExtensions
	{
		public static Task OnMessage<T>(this IHandleMessages<T> handler, TestableMessageHandlerContext context, Action<T> messageCreator) where T : IMessage
		{
			var message = Test.CreateInstance(messageCreator);
			return handler.Handle(message, context);
		}
		public static Task OnMessage<T>(this IHandleMessages<T> handler, TestableMessageHandlerContext context, T message) where T : IMessage
		{
			return handler.Handle(message, context);
		}
	}
}
