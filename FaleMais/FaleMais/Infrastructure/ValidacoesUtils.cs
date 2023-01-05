namespace Infrastructure
{
    public static class ValidacoesUtils
    {
        public static List<string> ObterErros(IDictionary<string, string[]> erros) =>
            erros
                .Select(erro => $"{erro.Key}: {erro.Value.FirstOrDefault()}")
                .ToList();
    }
}
