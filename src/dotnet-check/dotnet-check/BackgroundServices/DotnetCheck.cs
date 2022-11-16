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
            Console.Write(releaseInfo);
        }
    }

    public class ReleasesIndex
    {
        [JsonPropertyName("channel-version")]
        public string channelversion { get; set; }

        [JsonPropertyName("latest-release")]
        public string latestrelease { get; set; }

        [JsonPropertyName("latest-release-date")]
        public string latestreleasedate { get; set; }
        public bool security { get; set; }

        [JsonPropertyName("latest-runtime")]
        public string latestruntime { get; set; }

        [JsonPropertyName("latest-sdk")]
        public string latestsdk { get; set; }
        public string product { get; set; }

        [JsonPropertyName("release-type")]
        public string releasetype { get; set; }

        [JsonPropertyName("support-phase")]
        public string supportphase { get; set; }

        [JsonPropertyName("eol-date")]
        public string eoldate { get; set; }

        [JsonPropertyName("releases.json")]
        public string releasesjson { get; set; }
    }

    public class ReleaseInfo
    {
        [JsonPropertyName("releases-index")]
        public List<ReleasesIndex> releasesindex { get; set; }
    }


}
