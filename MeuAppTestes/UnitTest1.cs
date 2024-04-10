using System;
using Xunit;
using webapi.MeuApp.Models;

namespace MeuAppTestes;


public class UnitTest1
{
    [Fact]
    public void CriaDiretor()
    {
        var diretor = new Diretor("Teste Nome");
        Assert.Equal("Teste Nome", diretor.Nome);
    }
}