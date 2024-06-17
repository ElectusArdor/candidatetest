using System.ComponentModel;

namespace candidatetest
{
    internal interface ISerializable
    {
        public void Serilize(BindingList<OutputData> dataOut, string path) { }
    }
}
