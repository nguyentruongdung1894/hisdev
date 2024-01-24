namespace NencerHis.Modules.CommonManager
{
    public class ComboBoxModel
    {
        public int ID { get; set; }
        public string Value { get; set; }

        public ComboBoxModel(int id, string value)
        {
            ID = id;
            Value = value;
        }
    }
}
