using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository(ApplicationDbContext _context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
       return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int? id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
         _context.Products.Add(product);
         await _context.SaveChangesAsync();
         return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetProductCategoryAsync(int? id)
    {
        return await _context.Products.Include(p => p.Category)
            .SingleOrDefaultAsync(p => p.Id == id);
    }
}