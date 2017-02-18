namespace SportSquare.Models.Factories
{
    public interface IVenueFactory
    {
        Venue CreateVenue(double latitude, double longitude, string name, string phone, string webAddress, string address, string city, string image = null);
    }
}
