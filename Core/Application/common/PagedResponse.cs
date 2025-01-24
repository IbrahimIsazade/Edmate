using Application.Extensions;

namespace Application.common
{
    public class PagedResponse<T> : IPagedResponse<T>
        where T : class
    {
        public PagedResponse(IPageable pageable, IEnumerable<T> data, int totalCount)
        {
            this.Page = pageable.Page;
            this.Size = pageable.Size;
            this.Count = totalCount;
            this.Pages = (int)Math.Ceiling((totalCount * 1D) / pageable.Size);
            this.Data = data;
        }

        public int Page { get; set; }
        public int Pages { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public bool HasPrevious => this.Page > 1;
        public bool HasNext => this.Page < this.Pages;
        public IEnumerable<T> Data { get; set; }
    }
}
