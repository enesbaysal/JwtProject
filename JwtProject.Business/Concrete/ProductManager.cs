using jwtProject.DataAccess.Interfaces;
using jwtProject.Entities.Concrete;
using JwtProject.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.Concrete
{
    public class ProductManager:GenericManager<Product> , IProductService
    {
        private readonly IProduct _product;
        public ProductManager(IGeneric<Product> generic, IProduct product) :base(generic)
        {
            _product = product;     
        }
    }
}
