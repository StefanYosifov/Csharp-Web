using _Project_CheatSheet.Infrastructure.Data.Models.Base.Interfaces;

namespace _Project_CheatSheet.Infrastructure.Data.Models.Base
{
    public abstract class DeletableEntity : Entity, IDeletableEntity
    {
        public DateTime DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}