using System.Text.RegularExpressions;
namespace FlightBookingSystem.Models;
public class Airport
{
    public string icao { get; set; }
    public string iata { get; set; }
    public string name { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string country { get; set; }
    public int elevation { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string tz { get; set; }

    public string DisplayText => $"{city} - {name} ({iata})";

    public static bool TryParseFromDisplay(string displayText, List<Airport> airports, out Airport result)
    {
        // Extract IATA code from display text (last 3 characters in parentheses)
        var match = Regex.Match(displayText, @"\(([A-Z]{3})\)$");
        if (match.Success)
        {
            string iata = match.Groups[1].Value;
            result = airports.FirstOrDefault(a => a.iata == iata);
            return result != null;
        }
        result = null;
        return false;
    }
}