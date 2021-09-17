namespace Yas.Core
{
    public class NameValue<T>
    {
        public NameValue(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }

        public T Value { get; set; }
    }

    public class NameValue : NameValue<string>
    {
        public NameValue(string name, string value)
            : base(name, value)
        { }
    }
}