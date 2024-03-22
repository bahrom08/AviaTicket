namespace Infrastructure.GoogleFlights.Contracts.Requests;

public class SearchFlightsRequest
{
    public string From { get; set; }
    public string To { get; set; }
    public DateTime DepartDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int AdultsCount { get; set; }
    public int ChildrenCount { get; set; }
    public int InfantsCount { get; set; }
    public string Currency { get; set; }
}