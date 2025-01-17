using System;
using System.Threading.Tasks;
using log4net;
using NHibernate;
using NServiceBus.UnitOfWork;

namespace ReportingModule.Configuration
{
	public class SqlUnitOfWork: IManageUnitsOfWork
	{
		private readonly ITransaction _hibTransaction;

		static readonly ILog Logger = LogManager.GetLogger(typeof(SqlUnitOfWork));

		public SqlUnitOfWork(ISession hibSession)
		{
			_hibTransaction = hibSession.BeginTransaction();
		}

		public Task Begin()
		{
			Logger.Debug("UnitOfWork.Begin: noOp");
			return Task.CompletedTask;
		}

		public Task End(Exception ex)
		{
            if (ex == null)
			{
				Logger.Debug("UnitOfWork.End: committing changes to database(s)");
				
				if (_hibTransaction.IsActive)
					_hibTransaction.Commit();
			}
			else
            {
	            Logger.Debug("UnitOfWork.End: Exception, rolling back changes to database(s)", ex);

				if (_hibTransaction.IsActive)
					_hibTransaction.Rollback();				
			}

            _hibTransaction?.Dispose();
            Logger.Debug("UnitOfWork.End completed");
			return Task.CompletedTask;
		}
	}
}
