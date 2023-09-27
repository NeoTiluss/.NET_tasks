using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main()
    {
        await GenerateCountryDataFiles();
    }

    static async Task GenerateCountryDataFiles()
    {
        string apiUrl = "https://restcountries.com/v3.1/all";

        using (var httpClient = new HttpClient())
        {
            try
            {
                var response = await httpClient.GetStringAsync(apiUrl);
                JArray countries = JArray.Parse(response);

                foreach (var country in countries)
                {
                    string countryName = country["name"]["common"].ToString();
                    string fileName = $"{countryName}.txt";

                    using (StreamWriter writer = File.CreateText(fileName))
                    {
                        writer.WriteLine($"Country: {countryName}");
                        writer.WriteLine($"Region: {country["region"]}");
                        writer.WriteLine($"Subregion: {country["subregion"]}");

                        // Check if the "latlng" field exists
                        if (country["latlng"] != null && country["latlng"].HasValues)
                        {
                            writer.WriteLine($"Latitude: {country["latlng"][0]}");
                            writer.WriteLine($"Longitude: {country["latlng"][1]}");
                        }

                        writer.WriteLine($"Area: {country["area"]} sq km");
                        writer.WriteLine($"Population: {country["population"]}");
                    }

                    Console.WriteLine($"{fileName} created successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
