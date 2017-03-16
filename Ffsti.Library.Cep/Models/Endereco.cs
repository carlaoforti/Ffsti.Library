namespace Ffsti.Library.Cep.Models
{
    public class Endereco
    {
        public string Cep { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public TipoCep TipoCep { get; set; }
    }
}
