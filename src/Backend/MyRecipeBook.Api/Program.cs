using FluentValidation;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using MyRecipeBook.Api.Converters;
using MyRecipeBook.Application;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Infrastructure;
using MyRecipeBook.Infrastructure.Migrations;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new StringConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastrucuture(builder.Configuration);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserAccountValidator>();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportCulture = new List<CultureInfo> { new ("en"), new ("pt-BR"), new ("es")};

    options.DefaultRequestCulture = new RequestCulture("en");

    options.SupportedCultures = supportCulture;
    options.SupportedUICultures = supportCulture;

    options.RequestCultureProviders = [ new AcceptLanguageHeaderRequestCultureProvider() ];
});

var app = builder.Build();

var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizationOptions.Value);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await ExecuteMigrations();

app.Run();

async Task ExecuteMigrations()
{
    await using var scope = app.Services.CreateAsyncScope();

    DatabaseMigration.ExecuteMigrations(scope.ServiceProvider);
}
