var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Projeto web - LH Pets versão 1");

Banco banco = new Banco();

app.MapGet("/listaclientes" , (HttpContext context) => {

context.Response.WriteAsync(banco,GetlistaString());


});

app.UseStaticFiles();



app.Run();
