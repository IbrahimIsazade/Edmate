using Application.Services;
using Microsoft.AspNetCore.Http;
using Services.Registration;
using System.Text;
using Xabe.FFmpeg;

namespace Services
{
    [SingletonLifeTime]
    class AproximateTimeService : IAproximateTimeService
    {
        public int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var words = text.Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public async Task<int> GetApproximateReadingTimeAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty or null.");

            string content;
            using (var stream = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
            {
                content = await stream.ReadToEndAsync();
            }

            int wordCount = CountWords(content);
            int averageReadingSpeed = 200;

            return (int)Math.Ceiling((double)wordCount / averageReadingSpeed);
        }

        public async Task<int> GetVideoDurationAsync(IFormFile videoFile)
        {
            if (videoFile == null || videoFile.Length == 0)
                throw new ArgumentException("Video file is empty or null.");

            // Proccessing
            var tempFilePath = Path.GetTempFileName();
            using (var fileStream = new FileStream(tempFilePath, FileMode.Create))
            {
                await videoFile.CopyToAsync(fileStream);
            }

            try
            {
                var info = await FFmpeg.GetMediaInfo(tempFilePath);
                var duration = info.Duration;

                // Calculate
                int totalMinutes = (int)Math.Ceiling(duration.TotalMinutes);
                return totalMinutes;
            }
            finally
            {
                // Clean
                if (File.Exists(tempFilePath))
                    File.Delete(tempFilePath);
            }
        }
    }

}
