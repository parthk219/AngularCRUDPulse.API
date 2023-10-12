using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRUDPulse.API.Models.DTO
{// DTO USED TO SEPARATION OF CONCERN
    // CLIENT --> DTO --> API --> MODEL --> DB
    public class CreateCategoryRequestDTO
    {

        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}
