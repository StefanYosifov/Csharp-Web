namespace _Project_CheatSheet.Controllers.Resources.Interfaces
{
    using _Project_CheatSheet.Controllers.Resources.Models;
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Resources.Models;
    using Microsoft.AspNetCore.Mvc;

    public interface IResourceService
    {
        public Task<IEnumerable<ResourceModel>> publicResources();

        public Task<IEnumerable<ResourceModel>> myResources();

        public Task<StatusCodeResult> addResource(ResourceAddModel resourceModel);

        public Task<DetailResources> resourceById(string? resourceId);

    }
}
