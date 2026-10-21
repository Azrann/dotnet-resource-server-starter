using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceServer.SharedKernel
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>, IEntity
    {
        private TId id;

        protected Entity(TId id)
        {
            if (object.Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the default value.", "id");
            }

            this.id = id;
        }

        [Key]
        public TId Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public override bool Equals(object obj)
        {
            var entity = obj as Entity<TId>;
            if (entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #region IEquatable<Entity> Members

        public bool Equals(Entity<TId> other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }

        #endregion
    }
}
