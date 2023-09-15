using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using core;
using core.Entities;
using core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
    
    
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;
        
        public ProductsController( IGenericRepository<Product> productRepo, IGenericRepository<ProductType> productTypeRepo, 
            IGenericRepository<ProductBrand> productBrandRepo, IMapper mapper)
        {
            _mapper = mapper;
            
            _productRepo = productRepo;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecs();
            var products = await _productRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecs(id);
            
            var product = await _productRepo.GetEntityWithSpec(spec);


           return _mapper.Map<Product, ProductToReturnDto>(product);
        }

           [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _productBrandRepo.GetAllAsync();
            return Ok(productBrands);
        }

           [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productTypes = await _productTypeRepo.GetAllAsync();
            return Ok(productTypes);
        }
    }
}