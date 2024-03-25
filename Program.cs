using Microsoft.EntityFrameworkCore;
using webapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AplicattionDbContext>(options => options.UseSqlite("Data Source=myapp.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Use(async (context, next) =>
       {
           if (context.Request.Path == "/")
           {
               context.Response.Redirect("/swagger");
           }
           else
           {
               await next();
           }
       });

app.Run();

