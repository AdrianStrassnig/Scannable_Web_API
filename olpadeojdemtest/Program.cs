
Uri baseUri = new Uri("http://localhost:5250/api/Image/");
HttpClient client = new HttpClient();
client.BaseAddress = baseUri;

HttpResponseMessage response = await client.GetAsync("GettingImage");
if (!response.IsSuccessStatusCode)
    throw new InvalidOperationException();
string content = await response.Content.ReadAsStringAsync();

Console.ReadKey();