namespace candidatetest
{
    internal class InputData
    {
        public InputData(string tag, string type)
        {
            this.Tag = tag;
            this.Type = type;
            this.IsSelected = false;
        }

        public string Tag { get; private set; }
        public string Type { get; private set; }
        public bool IsSelected { get; set; }
    }
}
