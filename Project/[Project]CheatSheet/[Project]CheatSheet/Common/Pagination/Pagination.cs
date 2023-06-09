﻿namespace _Project_CheatSheet.Common.Pagination
{
    using Features.Issue.Models;
    using Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class Pagination<T> : List<T>
    {
        private const byte PageSize = 12;

        public Pagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public static async Task<Pagination<T>> CreateAsync(IQueryable<T> source, int pageIndex,
            byte itemsPerPage = PageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            return new Pagination<T>(items, count, pageIndex, PageSize);
        }

    }
}