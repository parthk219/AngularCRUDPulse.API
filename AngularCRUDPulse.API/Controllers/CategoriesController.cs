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


        }
    }
}
