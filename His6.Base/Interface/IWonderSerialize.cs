using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public interface IWonderSerialize
    {
        int FieldCount { get; }

        string Serialize(int index);

        void DeSerialize(int index, string value);

    }
}
