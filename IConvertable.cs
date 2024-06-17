using System.Collections.Generic;
using System.ComponentModel;

namespace candidatetest
{
    internal interface IConvertable
    {
        public void Convert(BindingList<InputData> dataIn, ref BindingList<OutputData> dataOut,
            Dictionary<string, Dictionary<string, string>> typeInfosDict) { }
    }
}
