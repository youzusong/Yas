using System;
using System.Collections.Generic;
using System.Text;

namespace Yas.Core.Text.Formatting
{
    /// <summary>
    /// 格式串文本解析器
    /// </summary>
    public class FormatStringTextTokenizer
    {
        /// <summary>
        /// 解析格式串
        /// </summary>
        /// <param name="format">格式串</param>
        /// <param name="includeBracketsForDynamicValues"></param>
        /// <returns></returns>
        public List<FormatStringText> Tokenize(string format)
        {
            var tokens = new List<FormatStringText>();
            var currentText = new StringBuilder();      // 当前文本
            var isInBracket = false;                    // 当前文本是否在括号内

            for (var i = 0; i < format.Length; i++)
            {
                var c = format[i];
                switch (c)
                {
                    case '{':
                        if (isInBracket)
                        {
                            throw new FormatException($"错误位置[{i}]：不能嵌套变量");
                        }

                        isInBracket = true;

                        if (currentText.Length > 0)
                        {
                            tokens.Add(new FormatStringText(currentText.ToString(), FormatStringTextType.Constant));
                            currentText.Clear();
                        }

                        break;
                    case '}':
                        if (!isInBracket)
                        {
                            throw new FormatException($"错误位置[{i}]：括号未开始");
                        }

                        isInBracket = false;

                        if (currentText.Length <= 0)
                        {
                            throw new FormatException($"错误位置[{i}]：括号内未包含任何内容");
                        }

                        tokens.Add(new FormatStringText(currentText.ToString(), FormatStringTextType.Dynamic));
                        currentText.Clear();

                        break;
                    default:
                        currentText.Append(c);
                        break;
                }
            }

            if (isInBracket)
            {
                throw new FormatException("括号未闭合");
            }

            if (currentText.Length > 0)
            {
                tokens.Add(new FormatStringText(currentText.ToString(), FormatStringTextType.Constant));
            }

            return tokens;
        }
    }
}
