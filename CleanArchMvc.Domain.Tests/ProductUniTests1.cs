using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUniTests1
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 100, "product image");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_WithInvalidParameters_ResultObjectInvalidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 100, "product image");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid price value");
    }

    [Fact]
    public void CreateProduct_WithInvalidParametersName_ResultObjectInvalidState()
    {
        Action action = () => new Product(1, "", "Product Description", 9.99m, 100, "product image");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact]
    public void CreateProduct_WithInvalidParametersDescription_ResultObjectInvalidState()
    {
        Action action = () => new Product(1, "Product Name", "", 9.99m, 100, "product image");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required");
    }

    [Fact]
    public void CreateProduct_WithInvalidParametersStock_ResultObjectInvalidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -100, "product image");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }

    [Fact]
    public void CreateProduct_WithInvalidParametersImage_ResultObjectInvalidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 100, " ");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

    }
    
    [Fact]
    public void CreayeProduct_WithNullImage_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 100, null);
        action.Should()
            .NotThrow<NullReferenceException>();
    }

    [Theory]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_Exception(int value)
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value, "product image");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }
}   









    