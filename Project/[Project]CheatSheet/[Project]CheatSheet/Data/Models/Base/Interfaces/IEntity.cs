namespace _Project_CheatSheet.Data.Models.Base.Interfaces
{
    public interface IEntity:IDeletableEntity
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}
