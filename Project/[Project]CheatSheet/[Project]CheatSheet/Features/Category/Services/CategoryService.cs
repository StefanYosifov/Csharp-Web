﻿namespace _Project_CheatSheet.Features.Category.Services
{
    using Infrastructure.Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CategoryService : ICategoryService
    {
        private readonly CheatSheetDbContext context;

        public CategoryService(CheatSheetDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            return await context.Categories
                .AsNoTracking().Select(x => new CategoryModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArrayAsync();
        }
    }
}