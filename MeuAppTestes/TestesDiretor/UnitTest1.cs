using System;
using Xunit;
using webapi.MeuApp.DTOs.Diretores;
using webapi.MeuApp.Validator.Diretores;
using FluentValidation.TestHelper;

namespace MeuAppTestes.TestesDiretor;


public class UnitTest1
{
    [Fact]
    public void NomeDiretorApresentaErroSeForVazio()
    {
        var validator = new DiretorDTOInputPostValidator();
        var dto = new DiretorDTOInputPost { Nome = null };
        var result = validator.TestValidate(dto);
        result.ShouldHaveValidationErrorFor(diretor => diretor.Nome);

    }
    [Fact]
    public void NomeDiretorPreenchidoNaoDeveConterErro()
    {
        var validator = new DiretorDTOInputPostValidator();
        var dto = new DiretorDTOInputPost { Nome = "Teste" };
        var result = validator.TestValidate(dto);
        result.ShouldNotHaveValidationErrorFor(diretor => diretor.Nome);

    }
}