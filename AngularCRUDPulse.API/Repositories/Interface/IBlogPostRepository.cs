using AngularCRUDPulse.API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRUDPulse.API.Repositories.Interface
{
   public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
    }
}
