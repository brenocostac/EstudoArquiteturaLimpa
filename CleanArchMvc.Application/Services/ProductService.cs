using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var products = await _productRepository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetById(int? id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> GetProductCategory(int? id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        var product = await _productRepository.GetProductCategoryAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task Add(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.CreateAsync(product);
    }

    public async Task Update(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.UpdateAsync(product);
    }

    public async Task Remove(int? id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        var product = await _productRepository.GetByIdAsync(id);
        await _productRepository.RemoveAsync(product);
    }
}