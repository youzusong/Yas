namespace Yas.Core.Text.Formatting
{
    /// <summary>
    /// 格式串文本
    /// </summary>
    public class FormatStringText
    {
        public FormatStringText(string value, FormatStringTextType type)
        {
            this.Value = value;
            this.Type = type;
        }

        public string Value { get; set; }

        public FormatStringTextType Type { get; set; }
    }
}
