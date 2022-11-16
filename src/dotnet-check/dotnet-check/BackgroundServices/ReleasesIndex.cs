using System.Text.Json.Serialization;

namespace CheckDotnetVersions.BackGroundServices
{
    public class ReleasesIndex
    {
        public int Id { get; set; }

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


}
