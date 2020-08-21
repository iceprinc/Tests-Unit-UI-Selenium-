using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class StringFormatter
    {
        public string ShortFileString(string path)
        {
            if (path == "")
                return "";
            if (path==null)
                throw new NullReferenceException("String NULL !");
            path = path.Substring(path.LastIndexOf('\\') + 1);
            int indexDot = path.LastIndexOf('.');
            if (indexDot != -1)
                path = path.Substring(0, path.LastIndexOf('.'));
            path = path.ToUpper() + ".TMP";
            return path;
        }
    }
}
