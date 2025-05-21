using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

/// PROBABLY WONT NEED THIS CLASS,USING WEP SCRAPING 

/// <summary>
/// Defines a service class to interact with the YouTube Data API.
/// </summary>
public class YouTubeService
{
    // An HttpClient object encapsulated within the YouTubeService class to make HTTP requests.
    private readonly HttpClient _httpClient;

    // API key to authenticate requests to the YouTube Data API. Replace "YOUR_API_KEY" with your actual YouTube API key. looking at a better way to do this
    private readonly string apiKey = "YOUR_API_KEY";

    /// <summary>
    /// Constructor for the YouTubeService class. It requires an HttpClient instance which is injected when the service is registered in the DI container.
    /// </summary>
    /// <param name="httpClient"></param>
    public YouTubeService(HttpClient httpClient)
    {
        _httpClient = httpClient; // Assign the injected HttpClient to the local field.
    }

    // Public method to perform a video search on YouTube. It is asynchronous and returns a task containing a string.
    // The method takes a search query as a parameter, which is used to form the request URL.
    public async Task<string> GetVideosAsync(string searchQuery)
    {
        // Constructs the URL for the YouTube API request. It includes the part parameter for the type of data returned,
        // the q parameter for the search query, and the key parameter for the API key.
        var url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&q={searchQuery}&key={apiKey}";

        // Sends an asynchronous GET request to the specified URL.
        var response = await _httpClient.GetAsync(url);

        // Ensures the response status code is in the range 200-299, which indicates success.
        // If the status code is outside this range, an exception is thrown.
        response.EnsureSuccessStatusCode();

        // Reads the response body as a string asynchronously and returns it.
        return await response.Content.ReadAsStringAsync();
    }
}