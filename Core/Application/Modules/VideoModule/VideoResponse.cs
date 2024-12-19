using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.VideoModule
{
    public class VideoResponse
    {
        public required string Title { get; set; }
        public required string VideoPath { get; set; }
        public required int CourseName { get; set; }
        public required int OrderNumber { get; set; }
        public required int Duration { get; set; }
    }
}
