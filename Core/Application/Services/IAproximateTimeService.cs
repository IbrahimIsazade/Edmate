using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAproximateTimeService
    {
        public Task<int> GetApproximateReadingTimeAsync(IFormFile file);
        public Task<int> GetVideoDurationAsync(IFormFile videoFile);
        public int CountWords(string text);
    }
}
