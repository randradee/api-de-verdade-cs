﻿using api_de_verdade.Domain.Dtos.ProductDtos;
using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Services;
using api_de_verdade.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace api_de_verdade.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _productService.GetProductsAsync();

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _productService.FindByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _productService.CreateProductAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            return Created(result.Message, result.Resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _productService.UpdateProduct(id, product);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _productService.DeleteProduct(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }
    }
}
