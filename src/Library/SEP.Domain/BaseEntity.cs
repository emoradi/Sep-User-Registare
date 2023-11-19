

namespace SEP.Domain
{
    public abstract class BaseEntity
    {
        #region Static Member(s)
        public static bool operator ==(BaseEntity leftObject, BaseEntity rightObject)
        {
            if (leftObject is null && rightObject is null)
            {
                return true;
            }

            if (leftObject is null && rightObject is not null)
            {
                return false;
            }

            if (leftObject is not null && rightObject is null)
            {
                return false;
            }

            return leftObject.Equals(rightObject);
        }
        public static bool operator !=(BaseEntity leftObject, BaseEntity rightObject)
        {
            return !(leftObject == rightObject);
        }
        #endregion /Static Member(s)

        protected BaseEntity() : base()
        {

        }


        int? _requestedHashCode;

        public override bool Equals(object anotherObject)
        {
            if (anotherObject is null)
            {
                return false;
            }

            if (anotherObject is not BaseEntity)
            {
                return false;
            }

            if (ReferenceEquals(this, anotherObject))
            {
                return true;
            }

            BaseEntity anotherEntity = anotherObject as BaseEntity;

            // For EF Core!
            if (GetRealType() != anotherEntity.GetRealType())
            {
                return false;
            }

            if (GetType() == anotherEntity.GetType())
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {

            return base.GetHashCode();
        }

        /// <summary>
        /// For EF Core!
        /// </summary>
        private System.Type GetRealType()
        {
            System.Type type = GetType();

            if (type.ToString().Contains("Castle.Proxies."))
            {
                return type.BaseType;
            }

            return type;
        }
    }
    public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        #region Static Member(s)
        public static bool operator ==(BaseEntity<TKey> leftObject, BaseEntity<TKey> rightObject)
        {
            if (leftObject is null && rightObject is null)
            {
                return true;
            }

            if (leftObject is null && rightObject is not null)
            {
                return false;
            }

            if (leftObject is not null && rightObject is null)
            {
                return false;
            }

            return leftObject.Equals(rightObject);
        }
        public static bool operator !=(BaseEntity<TKey> leftObject, BaseEntity<TKey> rightObject)
        {
            return !(leftObject == rightObject);
        }
        #endregion /Static Member(s)

        protected BaseEntity() : base()
        {

        }


        public TKey Id { get; protected set; }

        // **********

        int? _requestedHashCode;

        public bool IsTransient()
        {
            return EqualityComparer<TKey>.Default.Equals(Id, default(TKey));
        }

        public override bool Equals(object anotherObject)
        {
            if (anotherObject is null)
            {
                return false;
            }

            if (anotherObject is not BaseEntity<TKey>)
            {
                return false;
            }

            if (ReferenceEquals(this, anotherObject))
            {
                return true;
            }

            BaseEntity<TKey> anotherEntity = anotherObject as BaseEntity<TKey>;

            // For EF Core!
            if (GetRealType() != anotherEntity.GetRealType())
            {
                return false;
            }

            if (GetType() == anotherEntity.GetType())
            {
                if (IsTransient() || anotherEntity.IsTransient())
                {
                    return false;
                }
                else
                {
                    return Id.Equals(anotherEntity.Id);
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (IsTransient() == false)
            {
                if (_requestedHashCode.HasValue == false)
                {
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;
                }

                // XOR for random distribution. See:
                // https://docs.microsoft.com/archive/blogs/ericlippert/guidelines-and-rules-for-gethashcode
                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// For EF Core!
        /// </summary>
        private System.Type GetRealType()
        {
            System.Type type = GetType();

            if (type.ToString().Contains("Castle.Proxies."))
            {
                return type.BaseType;
            }

            return type;
        }
    }
}
