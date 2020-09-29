namespace ReportingModule.Core.Domains
{
	public interface IAggregateRoot
	{
	}

	public interface IAggregate<out TIdentifier>
	{
		TIdentifier Id { get; }
	}
}