namespace _Project_CheatSheet.Data.Models.Base
{
    using _Project_CheatSheet.Data.Models.Base.Interfaces;

    public class DeletableEntity : IDeletableEntity
    {

        public DateTime DeletedOn { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

    }
}
