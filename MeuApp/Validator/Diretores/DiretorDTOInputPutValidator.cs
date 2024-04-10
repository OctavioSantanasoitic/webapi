using FluentValidation;
using webapi.MeuApp.DTOs.Diretores;

namespace webapi.MeuApp.Validator.Diretores;

public class DiretorDTOInputPutValidator : AbstractValidator<DiretorDTOInputPut>
{
    public DiretorDTOInputPutValidator()
    {
        RuleFor(diretor => diretor.Nome).NotNull()
                                        .NotEmpty()
                                        .WithMessage("O Nome não pode ser Vazio!");

        RuleFor(diretor => diretor.Nome).Length(2, 250)
                                        .WithMessage("Tamanho Inválido!");

    }

}