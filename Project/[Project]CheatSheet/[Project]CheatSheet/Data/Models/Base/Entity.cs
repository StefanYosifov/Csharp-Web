namespace _Project_CheatSheet.Data.Models.Base
{
    using _Project_CheatSheet.Data.Models.Base.Interfaces;
    using System.ComponentModel.DataAnnotations;

    public abstract class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
