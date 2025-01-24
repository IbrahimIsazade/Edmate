using Application.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Application.common
{
    public class Pageable : IPageable
    {
        [FromRoute]
        public int Page { get; set; }

        [FromRoute]
        public int Size { get; set; }
    }
}
