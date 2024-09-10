using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest
{
    [Fact(DisplayName = "Create Category")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Category with invalid parameters Id")]
    public void CreateCategory_WithInvalidParameters_ResultObjectInvalidState()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid id Value");
    }
    
    [Fact(DisplayName = "Create Category with invalid parameters Name")]
    public void CreateCategory_WithInvalidParametersName_ResultObjectInvalidState()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
    
    
}