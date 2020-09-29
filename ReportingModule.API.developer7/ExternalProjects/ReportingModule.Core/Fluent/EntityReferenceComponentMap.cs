using FluentNHibernate.Mapping;

namespace ReportingModule.Core.Fluent
{
	public sealed class EntityReferenceComponentMap
	{
		public static void Map(CompositeElementPart<EntityReference> part)
		{
			part.Map(x => x.Id);
			part.Map(x => x.Description);
		}
	}
}