﻿using AngularCRUDPulse.API.Data;
using AngularCRUDPulse.API.Models.Domain;
using AngularCRUDPulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRUDPulse.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
                }

        public async Task<Category> GetById(Guid id) => await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Category> UpdateAsync(Category category)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (existingCategory != null)
            {
                dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();

                return existingCategory; // Return the updated category
            }

            return null; // This indicates that the category with the provided ID was not found.
        }

        //public async Task<Category?> GetById(Guid id)
        //{
        //    await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

        //}
    }
} 
