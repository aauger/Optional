namespace Optional
{
    public struct Option<T>
    {
        private readonly bool HasValue = false;
        private readonly T Value;

        private Option(bool hasValue, T value)
        {
            this.HasValue = hasValue;
            this.Value = value;
        }

        public static Option<T> Some(T item)
        {
            if (item is null)
                return new(false, default);
            else
                return new(true, item);
        }

        public static Option<T> None => new(false, default);

        public void Match(Action<T> some, Action none)
        {
            if (HasValue)
                some(this.Value);
            else
                none();
        }

        public void Then(Action<T> some)
        {
            if (HasValue)
                some(this.Value);
        }

        public Option<(T Left, K Right)> And<K>(Option<K> Other)
        {
            if (this.HasValue && Other.HasValue)
                return Option<(T, K)>.Some((this.Value, Other.Value));
            else
                return Option<(T, K)>.None;
        }

        public Option<T> Or(T other)
        {
            if (!HasValue)
                return Some(other);
            return this;
        }

        public T Unwrap()
        {
            if (HasValue)
                return this.Value;
            else
                throw new NullReferenceException("Cannot Unwrap None");
        }

        public T UnsafeUnwrap()
        {
            return this.Value;
        }
    }
}