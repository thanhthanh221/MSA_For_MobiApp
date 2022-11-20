using System.ComponentModel.DataAnnotations;

namespace Order.Domain.Core.Models
{
    public abstract class Enumeration : IComparable
    {
        public Enumeration(int Id, String name, String sub_title)
        {
            this.Id = Id;
            this.name = name;
            this.sub_title = sub_title;
        }

        // Prop
        public int Id {get; private set;}
        public String name {get; private set;}
        public String sub_title {get; private set;}

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