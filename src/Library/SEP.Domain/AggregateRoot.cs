
namespace SEP.Domain
{
	public abstract class AggregateRoot<TKey> : BaseEntity<TKey>, IAggregateRoot where TKey : IEquatable<TKey>
	{
		protected AggregateRoot() : base()
		{

		}

		
    }
}
