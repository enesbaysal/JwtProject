using jwtProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtProject.Entities.Dtos.ProductDto
{
    public class ProductUpdateDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
