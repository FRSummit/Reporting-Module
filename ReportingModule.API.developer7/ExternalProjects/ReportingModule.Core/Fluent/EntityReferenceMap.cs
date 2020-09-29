using FluentNHibernate.Mapping;

namespace ReportingModule.Core.Fluent
{
	public class EntityReferenceMap: ComponentMap<EntityReference>
	{
		 public EntityReferenceMap()
		 {
		 	Map(x => x.Id).CustomSqlType("int");
		 	Map(x => x.Description);
		 }
	}
}