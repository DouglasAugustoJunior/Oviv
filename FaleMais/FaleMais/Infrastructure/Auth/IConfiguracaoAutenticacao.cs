namespace FaleMais.Infrastructure.Auth
{
    public interface IConfiguracaoAutenticacao
    {
        string ChaveSecreta { get; init; }
        byte[] ChaveSecretaEncode { get; }
    }
}