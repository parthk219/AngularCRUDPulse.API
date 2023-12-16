using AngularCRUDPulse.API.Models.Domain;
using AngularCRUDPulse.API.Models.DTO;
using AngularCRUDPulse.API.Repositories.Implementation;
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
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICategoryRepository categoryRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository,ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(CreateBlogPostRequestDto request)
        {
            var blogPost = new BlogPost
            {
                Author = request.Author,
                Content = request.Author,
                FeatureImageUrl = request.featuredImageUrl,
                isVisible = request.isVisible,
                PublishedDate = request.PublishedDate,
                ShortDesc = request.shortDescription,
                Title = request.Title,
                UrlHandle = request.UrlHandle,
                Categories = new List<Category>()
            };

            foreach(var categoryGuid in request.Categories)
            {
                var existingCategory = await categoryRepository.GetById(categoryGuid);
                if (existingCategory != null)
                {
                    blogPost.Categories.Add(existingCategory);
                }
            }



            blogPost=await blogPostRepository.CreateAsync(blogPost);

            var response = new BlogPostDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Author,
                FeatureImageUrl = blogPost.FeatureImageUrl,
                isVisible = blogPost.isVisible,
                PublishedDate = blogPost.PublishedDate,
                shortDescription = blogPost.ShortDesc,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle


            };
            return Ok();
        
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await blogPostRepository.GetAllAsync();
            var response=new List<BlogPostDto>();
            foreach(var blogPost in blogPosts)
            {
                response.Add(new BlogPostDto
                {
                    Id = blogPost.Id,
                    Author = blogPost.Author,
                    Content = blogPost.Author,
                    FeatureImageUrl = blogPost.FeatureImageUrl,
                    isVisible = blogPost.isVisible,
                    PublishedDate = blogPost.PublishedDate,

                    shortDescription = blogPost.ShortDesc,
                    Title = blogPost.Title,
                    UrlHandle = blogPost.UrlHandle                });
            }
            
            return Ok(response);

        }
    }
}
