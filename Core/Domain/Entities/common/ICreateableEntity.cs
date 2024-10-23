namespace Domain.Entities.common
{
    public interface ICreateableEntity
    {
        DateTime? CreatedAt { get; set; }
        int CreatedBy { get; set; }
    }
}
