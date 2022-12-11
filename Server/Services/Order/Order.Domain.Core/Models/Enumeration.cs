using System.ComponentModel.DataAnnotations;

namespace Order.Domain.Core.Models
{
    public abstract class Enumeration : IComparable
    {
        public Enumeration(int Id, string name, string sub_title)
        {
            this.Id = Id;
            this.name = name;
            this.sub_title = sub_title;
        }

        // Prop
        public int Id {get; private set;}
        public string name {get; private set;}
        public string sub_title {get; private set;}

        // Overrding
        public override string ToString() => this.name;

        public override int GetHashCode() 
        {
            return Id.GetHashCode();
        }
        
        // So sánh
        public int CompareTo(object obj)
        {
            return  Id.CompareTo(((Enumeration)obj).Id);
        }
    }
}