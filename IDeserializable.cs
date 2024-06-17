using System.Collections.Generic;

namespace candidatetest
{
    internal interface IDeserializable
    {
        public Dictionary<string, Dictionary<string, string>> Deserialize(string path) { return null; }
    }
}
