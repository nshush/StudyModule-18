using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Введите ссылку на Youtube-видео: ");
        string videoUrl = Console.ReadLine();

        var commandInvoker = new CommandInvoker();

        commandInvoker.AddCommand(new GetVideoInfoCommand(videoUrl));

        await commandInvoker.ExecuteCommandsAsync();

        Console.Write("Хотите скачать видео? (да/нет): ");
        string downloadResponse = Console.ReadLine();

        if (downloadResponse?.ToLower() == "да")
        {
            Console.Write("Введите путь для сохранения видео (например, video.mp4): ");
            string outputPath = Console.ReadLine();

            commandInvoker.AddCommand(new DownloadVideoCommand(videoUrl, outputPath));

            await commandInvoker.ExecuteCommandsAsync();
        }
    }
}