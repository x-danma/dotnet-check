using dotnet_check.Data;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace CheckDotnetVersions.BackGroundServices
{
    public class DotnetCheck : BackgroundService
    {
        public DotnetCheck(HttpClient httpClient, IWebHostEnvironment environment)
        {
            this.httpClient = httpClient;
            timer = new(environment.IsDevelopment() ? TimeSpan.FromSeconds(5) : TimeSpan.FromHours(24));
        }

        private readonly PeriodicTimer timer;
        private readonly HttpClient httpClient;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (await timer.WaitForNextTickAsync(stoppingToken)
                && !stoppingToken.IsCancellationRequested)
            {
                await CheckAvailableDotnetVersions();
            }
        }

        private async Task CheckAvailableDotnetVersions()
        {
            var releaseInfo = await httpClient.GetFromJsonAsync<ReleaseInfo>("https://dotnetcli.blob.core.windows.net/dotnet/release-metadata/releases-index.json");

            if (releaseInfo == null)
            {
                return;
            }

            var existingReleaseIndexes = await httpClient.GetFromJsonAsync<List<ReleasesIndex>>("https://localhost:7158/api/ReleasesIndex");
            if (existingReleaseIndexes is null)
            {
                return;
            };

            await SaveReleaseIndexAsync(channelVersion: "6.0", releaseInfo, existingReleaseIndexes);
            await SaveReleaseIndexAsync(channelVersion: "7.0", releaseInfo, existingReleaseIndexes);

            Console.Write(releaseInfo);
        }

        private async Task SaveReleaseIndexAsync(string channelVersion, ReleaseInfo releaseInfo, List<ReleasesIndex> existingReleaseIndexes)
        {
            var releaseIndex = releaseInfo.releasesindex.First(ri => ri.channelversion == channelVersion);

            if (existingReleaseIndexes.Any(ri => ri.channelversion == releaseIndex.channelversion && ri.latestrelease == releaseIndex.latestrelease))
            {
                return;
            }

            await httpClient.PostAsJsonAsync("https://localhost:7158/api/ReleasesIndex", releaseIndex);

            SendMessage(releaseIndex);
        }

        private void SendMessage(ReleasesIndex releaseIndex)
        {
            Console.WriteLine($"""Hello! New version was updated! dotnet {releaseIndex.channelversion} has been updated to {releaseIndex.latestrelease} on date {releaseIndex.latestreleasedate}""");
        }
    }

    public class ReleaseInfo
    {
        [JsonPropertyName("releases-index")]
        public List<ReleasesIndex> releasesindex { get; set; }
    }


}
