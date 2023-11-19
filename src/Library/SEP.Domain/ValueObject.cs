
namespace SEP.Domain
{

	public abstract class ValueObject<T>
		where T : ValueObject<T>
	{
		public override bool Equals(object obj)
		{
			var valueObject = obj as T;

			if (ReferenceEquals(valueObject, null))
				return false;
		bool result =
				GetEqualityComponents()
				.SequenceEqual(valueObject.GetEqualityComponents());

			return result;
		}
		protected abstract System.Collections.Generic.IEnumerable<object> GetEqualityComponents();

		protected abstract bool EqualsCore(T other);

		public override int GetHashCode()
		{
			return GetHashCodeCore();
		}

		public virtual int GetHashCodeCore()
        {
			int result =
	GetEqualityComponents()
	.Select(x => x != null ? x.GetHashCode() : 0)
	.Aggregate((x, y) => x ^ y);

			return result;
		}

		public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
		{
			if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
				return true;

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
				return false;

			return a.Equals(b);
		}

		public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
		{
			return !(a == b);
		}
	}



}
