using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace Web.Helpers
{
    public static class AgilityPackHelper
    {
        public static string GetFirstImageSrc(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var imgs = doc.DocumentNode.SelectNodes("//img");
            return imgs?.FirstOrDefault()
                .GetAttributeValue("src", null);
        }
    }
}