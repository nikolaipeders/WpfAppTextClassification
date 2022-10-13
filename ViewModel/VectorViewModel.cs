using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTextClassification.Tools;

namespace WpfAppTextClassification.ViewModel
{
    public class VectorViewModel : Bindable
    {
        private static List<bool> _vectorA = new List<bool>();
        private static List<bool> _vectorB = new List<bool>();
        private string _selectedString;
        private string _numberOfTokensA;
        private string _numberOfTokensB;

        public VectorViewModel()
        {
            NumberOfTokensA = "Dimension: " + VectorA.Count();
            NumberOfTokensB = "Dimension: " + VectorB.Count();
        }

        public string SelectedString
        {
            get
            {
                return _selectedString;
            }
            set
            {
                _selectedString = value;
                propertyIsChanged();
            }
        }

        public string NumberOfTokensA
        {
            get
            {
                return _numberOfTokensA;
            }
            set
            {
                _numberOfTokensA = value;
                propertyIsChanged();
            }
        }

        public string NumberOfTokensB
        {
            get
            {
                return _numberOfTokensB;
            }
            set
            {
                _numberOfTokensB = value;
                propertyIsChanged();
            }
        }

        public static List<bool> VectorA
        {
            get
            {
                return _vectorA;
            }
            set
            {
                _vectorA = value;
            }
        }

        public static List<bool> VectorB
        {
            get
            {
                return _vectorB;
            }
            set
            {
                _vectorB = value;
            }
        }
    }
}
