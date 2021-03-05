using jwtProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtProject.Entities.Dtos.ProductDto
{
    public class ProductAddDto:IDto
    {
        public string Name { get; set; }
    }
}
