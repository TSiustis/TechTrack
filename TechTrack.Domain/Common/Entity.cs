﻿using System.ComponentModel.DataAnnotations.Schema;
using TechTrack.Domain.Common.Interfaces;

namespace TechTrack.Domain.Common
{
    public class Entity : IHasDomainEvent
    {
        int? _requestedHashCode;
        int _Id;
        public virtual int Id
        {
            get => _Id;
            set => _Id = value;
        }

        [NotMapped]
        public List<DomainEvent> DomainEvents { get; set; } = new();


        public bool IsTransient()
        {
            return this.Id == default(int);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }
        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
