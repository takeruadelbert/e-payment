using Newtonsoft.Json;

namespace BNITapCash.Classes.API.response
{
    public class PedestrianResponse : BaseResponse
    {
        [JsonProperty("id")]
        public int PeopleTicketId { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        public PedestrianResponse(int peopleTicketId, int total)
        {
            PeopleTicketId = peopleTicketId;
            Total = total;
        }
    }
}
