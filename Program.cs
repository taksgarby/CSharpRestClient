// the app calls Github API to get info about the projects 
//the end point is https://api.github.com/orgs/dotnet/repos


using System.Net.Http.Headers;

using HttpClient client = new();
//Accept header - accespt JSON responses
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
//User-Agent header is checked by the Github server
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    var json = await client.GetStringAsync(
        "https://api.github.com/orgs/dotnet/repos");

    Console.Write(json);
}