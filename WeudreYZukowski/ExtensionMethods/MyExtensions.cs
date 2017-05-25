using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeudreYZukowski.ExtensionMethods
{
    public static class MyExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}