using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppTextClassification.Model;

namespace WpfAppTextClassification.Service
{
    public class StringOperations
    {
        public static string GetFileName(string path, string filetype)
        {
            // a) skipping the extension .txt (4 chars)
            string name = path.Substring(0, path.Length-(filetype.Length));

            // b) skipping the front part
            int startPos = name.LastIndexOf('\\')+1;
            name = name.Substring(startPos,name.Length-startPos);

            return name;
        }

        /*
         * Proof of concept.  
         */
        public static string PerformStemming(string token)
        {
            if (token.EndsWith("ed"))
            {
                char c = token[token.Length - 2];
                bool isVowel = "aeiou".IndexOf(c) >= 0;
                if (isVowel)
                {
                    token = token.Substring(0, token.Length - 1);
                }
                else
                {
                    token = token.Substring(0, token.Length - 2);
                }
            }

            else if (token.EndsWith("s"))
            {
                char c = token[token.Length - 2];
                bool isVowel = "aeiou".IndexOf(c) >= 0;
                if (isVowel)
                {
                    token = token.Substring(0, token.Length - 1);
                }
            }
            return token; 
        }

        /*
         *   Uses iTextSharp to build a string by reading a PDF. 
        */
        public static string ConvertPDFToString(string path)
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                return text.ToString();
            }
        }
    }
}
