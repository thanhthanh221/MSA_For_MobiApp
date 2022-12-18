namespace Application.Common.Model
{
    public abstract class ValueObject<T>
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