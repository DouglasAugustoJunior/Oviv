using MiniValidation;
using FaleMais.Domain;
using FaleMais.Domain.DTO;
using FaleMais.Infrastructure;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class DDDService: BaseService<DDD>, IDDDService
    {
        private readonly IDDDRepository _dddRepository;

        public DDDService(IDDDRepository dddRepository): base(dddRepository) =>
            _dddRepository = dddRepository;

        public IResult Cadastrar(DDDCadastrarDTO dto)
        {
            if(string.IsNullOrEmpty(dto.DDD) || !int.TryParse(dto.DDD, out int _))
                return Results.BadRequest("Informe um DDD válido");
            if(_dddRepository.VerificarSeJaExiste(dto.DDD))
                return Results.BadRequest("DDD informado já existe");
            _dddRepository.Cadastrar(new DDD(dto.DDD));
            return Results.Ok("Cadastrado com sucesso!");
        }

        public IResult Atualizar(DDDAtualizarDTO dto)
        {
            if (!MiniValidator.TryValidate(dto, out var erros))
                return Results.BadRequest(ValidacoesUtils.ObterErros(erros));
            if (!int.TryParse(dto.Nome, out int _))
                return Results.BadRequest("DDD inválido!");
            if (_dddRepository.BuscarPorId(dto.Id) == null)
                return Results.BadRequest("DDD não encontrado para atualizar!");
            _dddRepository.Atualizar(dto.ToDDD());
            return Results.Ok("Atualizado com sucesso!");
        }

        public List<DDDListagemDTO> Listar() =>
            _dddRepository
                .Listar()
                .Select(ddd => new DDDListagemDTO()
                {
                    ID = ddd.Id,
                    Nome = ddd.Nome
                })
                .ToList();

        public override IResult Deletar(int id)
        {
            if (id <= 0)
                return Results.BadRequest("ID inválido para deletar");
            if(_dddRepository.ValidarExistenciaDeTarifaComDDD(id))
                return Results.BadRequest("DDD em uso, favor alterar tarifa com DDD primeiro");
            _dddRepository.Deletar(id);
            return Results.Ok("Excluído com sucesso!");
        }
    }
}
