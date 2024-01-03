
using AuthorsAndBooksGraphQL.Abstractions.Repositories;
using AuthorsAndBooksGraphQL.Abstractions.Services;
using AuthorsAndBooksGraphQL.Repositories;
using AuthorsAndBooksGraphQL.Schema;
using AuthorsAndBooksGraphQL.Services;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;

namespace AuthorsAndBooksGraphQL;

/// <summary>
/// Entry point for the program.
/// </summary>
/// <param name="args">Command line arguments.</param>
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IAuthorService, AuthorService>();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();

        builder.Services.AddScoped<ISchema, AuthorsSchema>(services => new AuthorsSchema(new SelfActivatingServiceProvider(services)));

        builder.Services.AddGraphQL(options => options.ConfigureExecution((opt, next) =>
        {
            opt.EnableMetrics = true;
            return next(opt);
        }).AddSystemTextJson());


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
            app.UseGraphQLAltair();
        }

        app.UseAuthorization();

        app.UseGraphQL<ISchema>();

        app.MapControllers();

        app.Run();
    }
}
