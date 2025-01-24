using Domain.StableModels;

namespace Application.common
{
    public interface ISortable
    {
        public string Column { get;}
        public SortOrder Order { get; }
    }
}
