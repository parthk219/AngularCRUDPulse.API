using AngularCRUDPulse.API.Data;
using AngularCRUDPulse.API.Models.Domain;
using AngularCRUDPulse.API.Models.DTO;
using AngularCRUDPulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRUDPulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        //private readonly ApplicationDbContext dbContext;
        //public CategoriesController(ApplicationDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO req)
        {
            // mapping dto to domain  & initialising or assigning
            var category = new Category
            {
                Name = req.Name,
                UrlHandle = req.UrlHandle
            };

            await categoryRepository.CreateAsync(category);
            //await dbContext.Categories.AddAsync(category);   /////-----> inside repository
            //await dbContext.SaveChangesAsync();
            // MAP domain MODEL  TO DTO
            var respone = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok();
            //----

        }


        [HttpGet]   // localhost /api/categories
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllAsync();
            var resp = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                resp.Add(new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }
            return Ok(resp);
        }


        [HttpGet]  // localhost/ api/ category /{id}
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var existingCategory = await categoryRepository.GetById(id);
            var resp = new CategoryDTO
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle
            };
            return Ok(resp);
        }

        //PUT
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategoty([FromRoute] Guid id, UpdateCategoryDto request)
        {
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            category = await categoryRepository.UpdateAsync(category);
            if (category == null)
            { return NotFound(); }
            else
            { return Ok(); }
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await categoryRepository.DeleteAsync(id);

            if (category is null)
            {
                return NotFound(); // Category with the provided id was not found
            }
            ////return category;
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
             return Ok(response);
        }
    }
}
