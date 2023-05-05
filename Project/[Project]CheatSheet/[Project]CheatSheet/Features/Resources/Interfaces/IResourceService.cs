namespace _Project_CheatSheet.Controllers.Resources.Interfaces
{
    using _Project_CheatSheet.Controllers.Resources.Models;
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Resources.Models;
    using Microsoft.AspNetCore.Mvc;

    public interface IResourceService
    {

        public Task<int> GetTotalPage();
        public Task<IEnumerable<ResourceModel>> GetPublicResources(int id);

        public Task<IEnumerable<ResourceModel>> GetMyResources();

        public Task<StatusCodeResult> AddResources(ResourceAddModel resourceModel);

        public Task<DetailResources> GetResourceById(string? resourceId);

    }
}
