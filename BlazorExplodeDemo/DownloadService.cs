using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace BlazorExplodeDemo;

public class DownloadService
{
    public async Task<(Stream Stream, string Name)> DownloadAudioAsync(string url)
    {
        var youtube = new YoutubeClient();

        var video = await youtube.Videos.GetAsync(url);

        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
        var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
        var stream = await youtube.Videos.Streams.GetAsync(streamInfo);

        return (stream, $"{video.Title}.mp3");
    }
}
