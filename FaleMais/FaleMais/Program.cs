using Service;
using Domain.DTO;
using Repository;
using Service.Interface;
using Infrastructure.Auth;
using Repository.Interface;
using Infrastructure.Database;
using Infrastructure.Documentation;

var builder = WebApplication.CreateBuilder(args);
var politica = builder.Configuration.GetValue<string>("policy");
var allowewHosts = builder.Configuration.GetValue<string>("AllowedHosts");
var configuracaoAutenticacao = new ConfiguracaoAutenticacao
{
    ChaveSecreta = builder.Configuration.GetValue<string>("SecretKey")
};

builder.Services.AddSingleton<IConfiguracaoAutenticacao>(configuracaoAutenticacao);
builder.Services.AddDbContext<IFaleMaisDbContext, FaleMaisDbContext>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDDDRepository, DDDRepository>();
builder.Services.AddScoped<ICustoChamadaRepository, CustoChamadaRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICustoChamadaService, CustoChamadaService>();
builder.Services.AddScoped<IDDDService, DDDService>();
builder.Services.AddScoped<IPlanoService, PlanoService>();
builder.Services.AddScoped<ICalcularService, CalcularService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(ConfiguracaoSwagger.ConfigurarSwagger());
builder.Services.AddCors(ConfiguracaoPoliticas.ConfigurarPoliticas(politica, allowewHosts));
builder.Services
    .AddAuthentication(ConfiguracaoAutenticacao.ConfigurarSchemes())
    .AddJwtBearer(ConfiguracaoAutenticacao.ConfigurarJwt(configuracaoAutenticacao.ChaveSecretaEncode));
builder.Services.AddAuthorization(ConfiguracaoAutorizacao.ConfigurarAutorizacoes());

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(politica);

app
    .MapGet(
        "/ddd",
        (IDDDService _dddService) => _dddService.Listar())
    .WithName("GetDDD")
    .WithTags("Listagens")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<string>(StatusCodes.Status403Forbidden)
    .Produces<List<DDDListagemDTO>>(StatusCodes.Status200OK);

app
    .MapPost(
        "/ddd",
        (IDDDService _dddService, DDDCadastrarDTO dto) => _dddService.Cadastrar(dto))
    .WithName("PostDDD")
    .WithTags("Cadastrar")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<string>(StatusCodes.Status200OK);

app
    .MapPut(
        "/ddd",
        (IDDDService _dddService, DDDAtualizarDTO dto) => _dddService.Atualizar(dto))
    .WithName("PutDDD")
    .WithTags("Atualizar")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<string>(StatusCodes.Status200OK);

app
    .MapDelete(
        "/ddd/{id}",
        (IDDDService _dddService, int id) => _dddService.Deletar(id))
    .WithName("DeleteDDD")
    .WithTags("Deletar")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<string>(StatusCodes.Status200OK);

app
    .MapGet(
        "/usuarios",
        (IUsuarioService _usuarioService) => _usuarioService.Listar())
    .WithName("GetUsuario")
    .WithTags("Listagens")
    .RequireAuthorization(ConfiguracaoAutorizacao.Administrador)
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<string>(StatusCodes.Status403Forbidden)
    .Produces<List<UsuariosListagemDTO>>(StatusCodes.Status200OK);

app
    .MapPost(
        "/usuarios",
        (IUsuarioService _usuarioService, UsuarioCadastrarDTO dto) => _usuarioService.Cadastrar(dto))
    .WithName("PostUsuario")
    .WithTags("Cadastrar")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<string>(StatusCodes.Status200OK);

app
    .MapPut(
        "/usuarios",
        (IUsuarioService _usuarioService, UsuarioAtualizarDTO dto) => _usuarioService.Atualizar(dto))
    .WithName("PutUsuario")
    .WithTags("Atualizar")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<string>(StatusCodes.Status200OK);

app
    .MapDelete(
        "/usuarios/{id}",
        (IUsuarioService _usuarioService, int id) => _usuarioService.Deletar(id))
    .WithName("DeleteUsuario")
    .WithTags("Deletar")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<string>(StatusCodes.Status200OK);

app
    .MapGet(
        "/tarifas",
        (ICustoChamadaService _custoChamadaService) => _custoChamadaService.Listar())
    .WithName("GetTarifa")
    .WithTags("Listagens")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<CustoChamadaListagemDTO>>(StatusCodes.Status200OK);

app
    .MapPost(
        "/tarifas",
        (ICustoChamadaService _custoChamadaService, CustoChamadaCadastrarDTO dto) => _custoChamadaService.Cadastrar(dto))
    .WithName("PostTarifa")
    .WithTags("Cadastrar")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<string>(StatusCodes.Status200OK);

app
    .MapPut(
        "/tarifas",
        (ICustoChamadaService _custoChamadaService, CustoChamadaAtualizarDTO dto) => _custoChamadaService.Atualizar(dto))
    .WithName("PutTarifa")
    .WithTags("Atualizar")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<string>(StatusCodes.Status200OK);

app
    .MapDelete(
        "/tarifas/{id}",
        (ICustoChamadaService _custoChamadaService, int id) => _custoChamadaService.Deletar(id))
    .WithName("DeleteTarifa")
    .WithTags("Deletar")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<string>(StatusCodes.Status200OK);

app
    .MapGet(
        "/tarifasParaInput",
        (ICustoChamadaService _custoChamadaService) => _custoChamadaService.ListarParaInput())
    .WithName("GetTarifasParaInput")
    .WithTags("Inputs")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<CustoChamadaDTO>>(StatusCodes.Status200OK);

app
    .MapGet(
        "/planos",
        (IPlanoService _planoService) => _planoService.Listar())
    .WithName("GetPlano")
    .WithTags("Listagens")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<List<PlanoListagemDTO>>(StatusCodes.Status200OK);

app
    .MapPost(
        "/calcular",
        (ICalcularService _calcularService, CalculosDTO calculos) => _calcularService.Calcular(calculos))
    .WithName("PostCalcular")
    .WithTags("Calculos")
    .Produces<string>(StatusCodes.Status401Unauthorized)
    .Produces<string>(StatusCodes.Status404NotFound)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<List<ResultadoCalculoDTO>>(StatusCodes.Status200OK);

app.MapPost(
        "/login",
        (ILoginService _loginService, LoginDTO login) => _loginService.Login(login))
    .WithName("PostLogin")
    .WithTags("Login")
    .AllowAnonymous()
    .Produces<string>(StatusCodes.Status404NotFound)
    .Produces<List<string>>(StatusCodes.Status400BadRequest)
    .Produces<AcessoDTO>(StatusCodes.Status200OK);

app.Run();
