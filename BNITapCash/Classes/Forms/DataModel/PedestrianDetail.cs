namespace BNITapCash.Classes.Forms.DataModel
{
    public class PedestrianDetail
    {
        public string PedestrianType;
        public int NumberOfPeople;
        public int PedestrianFare;

        public PedestrianDetail(string type, int number, int fare)
        {
            PedestrianType = type;
            NumberOfPeople = number;
            PedestrianFare = fare;
        }
    }
}
