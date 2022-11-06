using System.ComponentModel.DataAnnotations;

namespace Order.Domain.Core.Models
{
    public abstract class Enumeration : IComparable
    {
        public Enumeration(int Id, String name)
        {
            this.Id = Id;
            this.name = name;
        }

        // Prop
        public int Id {get; private set;}
        public String name {get; private set;}

        // Overrding
        public override string ToString() => this.name;

        public override int GetHashCode() => this.Id.GetHashCode();
        
        // So sánh
        public int CompareTo(object obj)
        {
            return  Id.CompareTo(((Enumeration)obj).Id);
        }
    }
}