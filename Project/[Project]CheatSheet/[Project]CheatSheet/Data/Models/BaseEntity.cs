namespace _Project_CheatSheet.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
    }
}
