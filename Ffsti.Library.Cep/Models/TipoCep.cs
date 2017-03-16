namespace Ffsti.Library.Cep.Models
{
    /// <summary>
    /// Tipos de CEP retornados
    /// </summary>
    public enum TipoCep
    {
        /// <summary>
        /// CEP Não Encontrado
        /// </summary>
        NaoEncontrado = 0,

        /// <summary>
        /// CEP completo
        /// </summary>
        CepCompleto = 1,

        /// <summary>
        /// Município com CEP único
        /// </summary>
        CepUnico = 2
    }
}
