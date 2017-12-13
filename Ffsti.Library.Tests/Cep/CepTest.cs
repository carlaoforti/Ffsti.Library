using System.Security;
using Ffsti.Library.Cep;
using Ffsti.Library.Cep.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ffsti.Library.Tests.Cep
{
    [TestClass]
    public class CepTest
    {
        [TestMethod]
        public void Consulta_Cep_Unico()
        {
            var result = ConsultaCep.PesquisaCep("13390000");
            Assert.IsTrue(result.TipoCep == TipoCep.CepUnico);
        }

        [TestMethod]
        public void Consulta_Cep_Completo()
        {
            var result = ConsultaCep.PesquisaCep("13414018");
            Assert.IsTrue(result.TipoCep == TipoCep.CepCompleto);
        }

        [TestMethod]
        public void Consulta_Cep_Nao_Encontrado()
        {
            var result = ConsultaCep.PesquisaCep("99999999");
            Assert.IsTrue(result.TipoCep == TipoCep.NaoEncontrado);
        }
    }
}
