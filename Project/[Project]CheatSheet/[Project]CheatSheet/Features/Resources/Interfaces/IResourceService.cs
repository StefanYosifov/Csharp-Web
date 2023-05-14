using _Project_CheatSheet.Data.Models;
using _Project_CheatSheet.Features.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace _Project_CheatSheet.Features.Resources.Interfaces
{
    public interface IResourceService
    {
        public int GetTotalPage();
        public Task<IEnumerable<ResourceModel>> GetPublicResources(int id);
        public Task<IEnumerable<ResourceModel>> GetMyResources();
        public Task<ResourceAddModel> AddResources(ResourceAddModel resourceModel);
        public Task<DetailResources> GetResourceById(string? resourceId);
        public Task<ResourceEditModel> EditResource(string id, ResourceEditModel resourceEdit);
        public Task<Resource> RemoveResource(string id);
    }
}