﻿namespace _Project_CheatSheet.Features.Resources.Interfaces
{
    using Common.Pagination;
    using Infrastructure.Data.Models;
    using Models;

    public interface IResourceService
    {
        public int GetTotalPage();
        public Task<Pagination<ResourceModel>> GetPublicResources(int id);
        public Task<IEnumerable<ResourceModel>> GetMyResources();
        public Task<string> AddResources(ResourceAddModel resourceModel);
        public Task<DetailResources> GetResourceById(string? resourceId);
        public Task<string> EditResource(string id, ResourceEditModel resourceEdit);
        public Task<string> RemoveResource(string id);
    }
}