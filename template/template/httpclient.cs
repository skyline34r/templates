public class SimpleCastClient
{
    private HttpClient _client;
    private ILogger<SimpleCastClient> _logger;
    private readonly string _apiKey;
 
    public SimpleCastClient(HttpClient client, ILogger<SimpleCastClient> logger, IConfiguration config)
    {
        _client = client;
        _client.BaseAddress = new Uri($"https://api.simplecast.com");
        _logger = logger;
        _apiKey = config["SimpleCastAPIKey"];
    }
 
    public async Task<List<Show>> GetShows()
    {
        var episodesUrl = new Uri($"/v1/podcasts/shownum/episodes.json?api_key={_apiKey}", UriKind.Relative);
        var res = await _client.GetAsync(episodesUrl);
        return await res.Content.ReadAsAsync<List<Show>>();
    }
}