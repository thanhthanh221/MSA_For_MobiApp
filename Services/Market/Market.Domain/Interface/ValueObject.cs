namespace Market.Domain.Models
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            return obj is ValueObject<T>;
        }
        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }

    }
}
