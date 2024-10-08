using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    private ApplicationDbContext _context = context;

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int? id)
    {
       return await context.Categories.FindAsync(id);
        
    }

    public async Task<Category?> CreateAsync(Category? category)
    {
       context.Categories.Add(category);
       await context.SaveChangesAsync();
       return category;
       
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        context.Categories.Update(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> RemoveAsync(Category category)
    {
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        return category;
    }
}