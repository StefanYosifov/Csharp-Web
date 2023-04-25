namespace CheatSheetProject.Services.Contracts
{
    using CheatSheetProject.Models;
    using Microsoft.AspNetCore.Mvc;

    public interface IResource 
    {
        Task<IEnumerable<ResourceModel>> GetAllPublicResources();

        Task<IEnumerable<ResourceModel>> getMyResources(int userId);
        Task<ResourceModel> addResource(string title,string content,string ImageUrl)
    }
}
