using HttpClientFactoryProject.Configuration;
using HttpClientFactoryProject.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; 

builder.Services.Configure<ApiConfig>(configuration.GetSection(nameof(ApiConfig)));
builder.Services.AddSingleton<IApiConfig>(x => x.GetRequiredService<IOptions<ApiConfig>>().Value);

//registrar http
builder.Services.AddHttpClient<ITodoService, TodoService>(
    b => b.BaseAddress = new Uri(configuration["ApiConfig:BaseUrl"]));
  
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();