﻿using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Repository.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly IContext context;
        public CategoryRepository(IContext context)
        {
                this.context = context;
        }
       // [Authorize()]
        public async Task< Category> AddItem(Category item)
        {
           await context.Categories.AddAsync(item); 
           await context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            context.Categories.Remove(await GetById(id)); 
           await context.Save();
        }

        public async Task< List<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
           return await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> UpdateItem(int id, Category item)
        {
            var category=await GetById(id);
            category.Name = item.Name;
           await context.Save();
            return category;
        }
    }
}
