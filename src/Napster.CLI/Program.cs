using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Napster.CLI;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using Napster.Domain.AggregatesModel.GenreAggregate;
using Napster.Infrastructure.DataAccess.Mongo;
using Napster.Infrastructure.DataAccess.Mongo.Repositories;

var builder = new HostBuilder();

builder.ConfigureLogging(builder => builder.AddConsole());

builder.ConfigureAppConfiguration((builder, configure) =>
{
    configure.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
});

builder.ConfigureServices((builder, services) =>
{
    services.Configure<NapsterSettings>(builder.Configuration.GetSection("NapsterDatabase"));
    services.AddSingleton<NapsterContext>();
    services.AddScoped<IGenreRepository, GenreRepository>();
    services.AddScoped<IArtistRepository, ArtistRepository>();
    services.AddScoped<IAlbumRepository, AlbumRepository>();
});

builder.RunCommandLineApplicationAsync<Application>(args);
