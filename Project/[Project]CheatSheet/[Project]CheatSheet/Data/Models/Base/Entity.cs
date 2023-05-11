using _Project_CheatSheet.Data.Models.Base.Interfaces;

namespace _Project_CheatSheet.Data.Models.Base
{
    public abstract class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }
    }
}