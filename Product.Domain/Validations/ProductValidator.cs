using FluentValidation;
using Product.Domain.Entities;

namespace Product.Domain.Validations
{
    public class ProductValidator : AbstractValidator<ProductEntity>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name requerido");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Precio mayor a cero")
                .NotEmpty()
                .WithMessage("Precio requerido");

            RuleFor(x => x.Stock)
                .GreaterThan(0)
                .WithMessage("Stock mayor a cero")
                .NotEmpty()
                .WithMessage("Stock requerido");
        }
    }
}