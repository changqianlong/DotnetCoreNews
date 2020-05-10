using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QianziNews.Data
{
    public class TextManage
    {
        public static string ToHtml(string text)
        {
            text = text.Replace(" ", "&nbsp;&nbsp;");
            text = text.Replace(Environment.NewLine, "<br/>");
            return text;
        }

        public static string ToText(string text)
        {
            text = text.Replace("&nbsp;&nbsp;", " ");
            text = text.Replace("<br/>", Environment.NewLine);
            return text;
        }
    }
}
