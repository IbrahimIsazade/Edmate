namespace Application.common
{
    public interface IPageable
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
