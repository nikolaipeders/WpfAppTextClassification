using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppTextClassification.Model;
using WpfAppTextClassification.ViewModel;

namespace WpfAppTextClassification.Service
{
    public class Categorizer
    {
        public static BagOfWords bagOfWords = new BagOfWords();
        public static Vectors vectors = new Vectors();

        public static string CategorizeText(string text)
        {
            List<int> vectorABits = new List<int>();
            List<int> vectorBBits = new List<int>();

            // convert class vectors to ints
            foreach (var v in vectors.GetVectorsInA())
            {
                foreach (var bit in v)
                {
                    vectorABits.Add(Convert.ToInt32(bit));
                }
            }

            foreach (var v in vectors.GetVectorsInB())
            {
                foreach (var bit in v)
                {
                    vectorBBits.Add(Convert.ToInt32(bit));
                }
            }

            // tokenize uploaded text
            List<string> textToken = Tokenization.Tokenize(text);

            // to vector
            List<bool> uploadedTextVector = new List<bool>();

            foreach (string key in bagOfWords.GetAllWordsInDictionary())
            {
                if (textToken.Contains(key))
                {
                    uploadedTextVector.Add(true);
                }
                else
                {
                    uploadedTextVector.Add(false);
                }
            }

            // convert uploaded vector to ints
            List<int> uploadedTextVectorAsInt = new List<int>();
            foreach (var bit in uploadedTextVector)
            {
                uploadedTextVectorAsInt.Add(Convert.ToInt32(bit));
            }

            // distance between uploaded vector as ints and class a vector
            double sumSquareA = 0;
            for (int i = 0; i < uploadedTextVectorAsInt.Count; i++)
            {
                sumSquareA += Math.Pow(uploadedTextVectorAsInt[i] - vectorABits[i], 2);
            }
            double distanceA = Math.Sqrt(sumSquareA);

            // distance between uploaded vector as ints and class b vector
            double sumSquareB = 0;
            for (int i = 0; i < uploadedTextVectorAsInt.Count; i++)
            {
                sumSquareB += Math.Pow(uploadedTextVectorAsInt[i] - vectorBBits[i], 2);
            }
            double distanceB = Math.Sqrt(sumSquareB);

            // if x apply y
            if (distanceA > distanceB)
            {
                return "Class B";
            }
            else
            {
                return "Class A";
            }
        }
    }
}
