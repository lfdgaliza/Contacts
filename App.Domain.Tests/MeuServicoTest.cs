using App.Domain.Contracts.Repository;
using App.Domain.Contracts.Service;
using App.Domain.Dto;
using App.Impl.Service;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace App.Domain.Tests
{

    public class MeuServicoTest
    {
        [Fact]
        public void RetornarTudo_DeveRetornarTodosOsItens()
        {
            var massa = new List<RetornoDto>
            {
                new RetornoDto { Prop1 = "String1", Prop2 = 1, Prop3 = DateTime.Now},
                new RetornoDto { Prop1 = "String2", Prop2 = 2, Prop3 = DateTime.Now},
                new RetornoDto { Prop1 = "String3", Prop2 = 3, Prop3 = DateTime.Now}
            };

            var mock = new Mock<IMeuRepository>();
            mock
                .Setup(rep => rep.ConsultarRetorno(null))
                .Returns(massa);

            IMeuService service = new MeuService(mock.Object);

            var tudo = service.RetornarTudo();

            Assert.True(tudo.Count == massa.Count);
        }

        [Fact]
        public void RetornarAlgo_DeveRetornarApenasItemPedido()
        {
            var massa = new List<RetornoDto>
            {
                new RetornoDto { Prop1 = "String2", Prop2 = 2, Prop3 = DateTime.Now}
            };

            var mock = new Mock<IMeuRepository>();
            mock
                .Setup(rep => rep.ConsultarRetorno(2))
                .Returns(massa);

            IMeuService service = new MeuService(mock.Object);

            var retorno = service.RetornarAlgo(2);

            Assert.True(retorno == massa[0]);
        }
    }
}
