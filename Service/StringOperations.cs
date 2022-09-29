using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTextClassification.Service
{
    public class StringOperations
    {
        public static string getFileName(string path, string filetype)
        {
            // a) skipping the extension .txt (4 chars)
            string name = path.Substring(0, path.Length-(filetype.Length));

            // b) skipping the front part
            int startPos = name.LastIndexOf('\\')+1;
            name = name.Substring(startPos,name.Length-startPos);

            return name;
        }
    }
}
