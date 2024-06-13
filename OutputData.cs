
namespace candidatetest
{
    public class OutputData
    {
        public OutputData() { }

        public OutputData(string tag, int Offset)
        {
            this.Tag = tag;
            this.Adress = Offset;
        }
        public string Tag { get; set; }
        public int Adress { get; set; }
    }
}
