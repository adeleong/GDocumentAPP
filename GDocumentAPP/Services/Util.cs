using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace GDocumentAPP.Services
{
    public static class Util
    {
        public static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}