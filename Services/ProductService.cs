using api_de_verdade.Domain.Dtos.CategoryDtos;
using api_de_verdade.Domain.Dtos.ProductDtos;
using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Models.Enums;
using api_de_verdade.Domain.Repositories;
using api_de_verdade.Domain.Services;
using api_de_verdade.Domain.Services.Communication;
using api_de_verdade.Extensions;
using AutoMapper;

namespace api_de_verdade.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<IEnumerable<GetProductDto>>> GetProductsAsync()
        {
            var products = await _productRepository.GetAll();
            
            var responseProductsDto = new List<GetProductDto>();

            foreach (var product in products)
            {
                var productToPush = new GetProductDto(
                    product.Id,
                    product.Name, 
                    product.QuantityInPackage,
                    Enum.GetName(typeof(EUnitOfMeasurement), product.UnitOfMeasurement).ToString(), 
                    product.CategoryId, 
                    _mapper.Map<Category, GetCategoryDto>(product.Category)
                    );

                responseProductsDto.Add(productToPush);
            }

            return new Response<IEnumerable<GetProductDto>>(responseProductsDto);
        }

        public async Task<Response<GetProductDto>> FindByIdAsync(int id)
        {
            var product = await _productRepository.FindByIdAsync(id);

            if(product == null)
            {
                return new Response<GetProductDto>("Produto não encontrado");
            }

            var responseProduct = _mapper.Map<Product, GetProductDto>(product);

            return new Response<GetProductDto>(responseProduct);
        }

        public async Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto product)
        {
            var productToCreate = new Product(
                                                product.Name,
                                                product.QuantityInPackage,
                                                product.UnitOfMeasurement,
                                                product.CategoryId
                                            );

            try
            {
                var result = await _productRepository.CreateAsync(productToCreate);
                await _unitOfWork.CompleteAsync();

                return new Response<CreateProductDto>(product);
            }
            catch(Exception ex)
            {
                return new Response<CreateProductDto>($"erro: {ex.Message}");
            }
        }

        public async Task<Response<UpdateProductDto>> UpdateProduct(int id, UpdateProductDto product)
        {
            var currentProduct = await _productRepository.FindByIdAsync(id);

            if(currentProduct == null)
            {
                return new Response<UpdateProductDto>("Produto não encontrado");
            }

            currentProduct.Name = product.Name;
            currentProduct.QuantityInPackage = product.QuantityInPackage;
            currentProduct.UnitOfMeasurement = product.UnitOfMeasurement;
            currentProduct.CategoryId = product.CategoryId;

            try
            {
                _productRepository.Update(currentProduct);
                await _unitOfWork.CompleteAsync();

                return new Response<UpdateProductDto>(product);
            }
            catch(Exception ex)
            {
                return new Response<UpdateProductDto>($"erro: {ex.Message}");
            }
        }

        public async Task<Response<GetProductDto>> DeleteProduct(int id)
        {
            var product = await _productRepository.FindByIdAsync(id);

            if (product == null)
            {
                return new Response<GetProductDto>("Produto não encontrado");
            }

            try
            {
                var responseProduct = _mapper.Map<Product, GetProductDto>(product);

                _productRepository.Delete(product);
                await _unitOfWork.CompleteAsync();

                return new Response<GetProductDto>(responseProduct);
            }
            catch (Exception ex)
            {
                return new Response<GetProductDto>($"erro: {ex.Message}");
            }
        }
    }
}