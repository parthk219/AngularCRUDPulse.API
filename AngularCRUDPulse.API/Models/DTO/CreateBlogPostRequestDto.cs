using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRUDPulse.API.Models.DTO
{
    public class CreateBlogPostRequestDto
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        //public string ShortDesc { get; set; } //p
        public string shortDescription { get; set; } //p
        public string Content { get; set; }
        //public string FeatureImageUrl { get; set; }  //p
        public string featuredImageUrl { get; set; }  //p
        public string UrlHandle { get; set; }
        public string Author { get; set; }
        public bool isVisible { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
