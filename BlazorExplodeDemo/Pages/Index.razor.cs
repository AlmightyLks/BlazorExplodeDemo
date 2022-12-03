using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorExplodeDemo.Pages;

public partial class Index
{
    [Inject]
    public DownloadService DownloadService { get; set; } = null!;

    private string? videoUrl;

    private async Task DownloadFileFromStream()
    {
        if (String.IsNullOrWhiteSpace(videoUrl))
            return;

        (var fileStream, var fileName) = await DownloadService.DownloadAudioAsync(videoUrl);

        using var streamRef = new DotNetStreamReference(stream: fileStream);
        await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
    }
}
