using FastEndpoints;
using FluentValidation;

namespace OrbitCore.CatalogService.Application.UseCases.CreateProduct
{
    public class CreateProductValidator : Validator<CreateProductInput>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome do produto é obrigatório.")
                .MinimumLength(5)
                .WithMessage("O nome do produto está muito curto.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("A descrição do produto é obrigatória.")
                .MinimumLength(5)
                .WithMessage("A descrição do produto está muito curta.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("O preço do produto não pode ser menor ou igual a 0.");
        }
    }
}
