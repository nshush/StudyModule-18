using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Common;

public class GetVideoInfoCommand : ICommand
{
    private readonly string _videoUrl;

    public GetVideoInfoCommand(string videoUrl)
    {
        _videoUrl = videoUrl;
    }

    public async Task ExecuteAsync()
    {
        var youtubeClient = new YoutubeClient();

        var video = await youtubeClient.Videos.GetAsync(_videoUrl);
        Console.WriteLine($"Название: {video.Title}");
        Console.WriteLine($"Описание: {video.Description}");
    }
}