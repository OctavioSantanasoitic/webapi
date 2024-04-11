using System;
using Xunit;
using webapi.MeuApp.DTOs.Filmes;
using webapi.MeuApp.Validator.Filmes;
using FluentValidation.TestHelper;

namespace MeuAppTestes.TestesFilmes;


public class UnitTestesFilmes
{
    [Fact]
    public void NomeFilmeEGeneroApresentaErroSeForVazio()
    {
        var validator = new FilmeDTOInputPostValidator();
        var dto = new FilmeDTOInputPost(null, DateTime.Now, null, 0);
        var result = validator.TestValidate(dto);
        result.ShouldHaveValidationErrorFor(filme => filme.Titulo);
        result.ShouldHaveValidationErrorFor(filme => filme.Genero);

    }
}