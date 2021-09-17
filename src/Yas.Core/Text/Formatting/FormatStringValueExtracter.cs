using System;
using System.Collections.Generic;
using System.Linq;

namespace Yas.Core.Text.Formatting
{
    /// <summary>
    /// 格式串变量值提取器
    /// </summary>
    public class FormatStringValueExtracter
    {
        /// <summary>
        /// 提取格式串变量值
        /// </summary>
        /// <param name="str">字符串内容</param>
        /// <param name="format">格式串</param>
        /// <param name="ignoreCase">忽略大小写</param>
        /// <returns></returns>
        public static ExtractionResult Extract(string str, string format, bool ignoreCase = false)
        {
            if (str == format)
                return new ExtractionResult(true);

            var formatTexts = new FormatStringTextTokenizer().Tokenize(format);
            if (formatTexts.IsNullOrEmpty())
                return new ExtractionResult(str == "");

            var result = new ExtractionResult(true);
            var strComparison = ignoreCase
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal;

            for (var i = 0; i < formatTexts.Count; i++)
            {
                var currText = formatTexts[i];
                var prevText = i > 0 ? formatTexts[i - 1] : null;

                if (currText.Type == FormatStringTextType.Dynamic)
                    continue;

                if (i == 0)
                {
                    if (!str.StartsWith(currText.Value, strComparison))
                    {
                        result.IsMatch = false;
                        return result;
                    }

                    str = str.Substring(currText.Value.Length);
                }
                else
                {
                    var matchIndex = str.IndexOf(currText.Value, strComparison);
                    if (matchIndex < 0)
                    {
                        result.IsMatch = false;
                        return result;
                    }

                    result.Matches.Add(new NameValue(prevText.Value, str.Substring(0, matchIndex)));
                    str = str.Substring(matchIndex + currText.Value.Length);
                }
            }

            var lastText = formatTexts.Last();
            if (lastText.Type == FormatStringTextType.Dynamic)
            {
                result.Matches.Add(new NameValue(lastText.Value, str));
            }

            return result;
        }

        /// <summary>
        /// 格式串提取结果
        /// </summary>
        public class ExtractionResult
        {
            public ExtractionResult(bool isMatch)
            {
                this.IsMatch = isMatch;
                this.Matches = new List<NameValue>();
            }

            public bool IsMatch { get; set; }

            public List<NameValue> Matches { get; private set; }
        }
    }
}
