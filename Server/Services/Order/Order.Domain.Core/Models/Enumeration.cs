using System.ComponentModel.DataAnnotations;

namespace Order.Domain.Core.Models
{
    public abstract class Enumeration : IComparable
    {
        protected Enumeration(int Id, string name, string sub_title)
        {
            this.Id = Id;
            this.name = name;
            this.sub_title = sub_title;
        }

        // Prop
        public int Id {get; private set;}
        public string name {get; private set;}
        public string sub_title {get; private set;}

        public override int GetHashCode() 
        {
            return Id.GetHashCode();
        }
        
        // So sánh
        public int CompareTo(object obj)
        {
            return  Id.CompareTo(((Enumeration)obj).Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) {
                return true;
            }

            if (ReferenceEquals(obj, null)) {
                return false;
            }

            throw new NotImplementedException();
        }

        public static bool operator ==(Enumeration left, Enumeration right)
        {
            if (ReferenceEquals(left, null)) {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !(left == right);
        }

        public static bool operator <(Enumeration left, Enumeration right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Enumeration left, Enumeration right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Enumeration left, Enumeration right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Enumeration left, Enumeration right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}