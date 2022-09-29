using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTextClassification.Model;

namespace WpfAppTextClassification.ViewModel
{
    public abstract class AbstractVectorsBuilder
    {
            public abstract void AddVectorToA(List<bool> vector);

            public abstract void AddVectorToB(List<bool> vector);

        //  get the complete Vectors-object
        public abstract Vectors GetVectors();

       

    }
}
