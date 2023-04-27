using DesafioSiemens.Endpoints.Cidades;
using DesafioSiemens.Endpoints.Clientes;
using DesafioSiemens.Infra.Dados;
using IWantApp.Infra.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(
    builder.Configuration["ConnectionString:DesafioSiemensDb"]);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapMethods(CidadePost.Template, CidadePost.Methods, CidadePost.Handle);
app.MapMethods(CidadePut.Template, CidadePut.Methods, CidadePut.Handle);
app.MapMethods(CidadeGetAll.Template, CidadeGetAll.Methods, CidadeGetAll.Handle);
app.MapMethods(CidadeDelete.Template, CidadeDelete.Methods, CidadeDelete.Handle);

app.MapMethods(ClientePost.Template, ClientePost.Methods, ClientePost.Handle);
app.MapMethods(ClientePut.Template, ClientePut.Methods, ClientePut.Handle);
app.MapMethods(ClienteGetAll.Template, ClienteGetAll.Methods, ClienteGetAll.Handle);
app.MapMethods(ClienteDelete.Template, ClienteDelete.Methods, ClienteDelete.Handle);

app.Run();

