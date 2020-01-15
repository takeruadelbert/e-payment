using Newtonsoft.Json;

namespace BNITapCash.Classes.API.request
{
    class DataPedestrianTypeQuantity
    {
        [JsonProperty("name")]
        private string Name;

        [JsonProperty("qty")]
        private int Quantity;

        [JsonProperty("note")]
        private string Note;

        public DataPedestrianTypeQuantity(string name, int qty, string note)
        {
            Name = name;
            Quantity = qty;
            Note = note;
        }
    }
}
