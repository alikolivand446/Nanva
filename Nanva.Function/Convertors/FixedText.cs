using System;
using System.Collections.Generic;
using System.Text;

namespace Nanva.Function.Convertors
{
    public class FixedText
    {
        public static string Fixed(string text)
        {
            return text.Trim().ToLower();
        }

    }
}
