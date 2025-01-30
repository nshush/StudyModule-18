using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Converter;

public class DownloadVideoCommand : ICommand
{
    private readonly string _videoUrl;
    private readonly string _outputFilePath;

    public DownloadVideoCommand(string videoUrl, string outputFilePath)
    {
        _videoUrl = videoUrl;
        _outputFilePath = outputFilePath;
    }

    public async Task ExecuteAsync()
    {
        var youtubeClient = new YoutubeClient();

        await youtubeClient.Videos.DownloadAsync(_videoUrl, _outputFilePath, builder => builder
            .SetPreset(ConversionPreset.UltraFast));

        Console.WriteLine($"Видео скачано и сохранено в: {_outputFilePath}");
    }
}