using FluentValidation;
using webapi.DTOs.Diretores;
using webapi.DTOs.Filmes;

namespace webapi.Validator.Filmes;

public class FilmeDTOInputPostValidator : AbstractValidator<FilmeDTOInputPost>
{
    public FilmeDTOInputPostValidator()
    {
        RuleFor(filme => filme.Titulo).NotNull()
                                      .NotEmpty()
                                      .WithMessage("O campo Nome do Filme não pode ser Vazio!");

        RuleFor(filme => filme.Titulo).Length(2, 250)
                                      .WithMessage("Tamanho do Campo Inválido!");

        RuleFor(filme => filme.Genero).NotNull()
                                      .NotEmpty()
                                      .WithMessage("O campo Gênero do Filme não pode ser Vazio!");

        RuleFor(filme => filme.Ano).NotNull()
                                   .NotEmpty()
                                   .WithMessage("O campo Data do Filme não pode ser Vazio!");

        RuleFor(filme => filme.DiretorId).NotNull()
                                         .NotEmpty()
                                         .WithMessage("O campo do Id do Diretor não pode ser Vazio!");



    }

}