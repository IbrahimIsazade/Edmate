using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.common
{
    public interface IPagedResponse<T>
        where T : class
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public bool HasPrevious => this.Page > 1;
        public bool HasNext => this.Page < this.Pages;
        public IEnumerable<T> Data { get; set; }
    }
}
