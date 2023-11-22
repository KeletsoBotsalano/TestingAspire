using k8s.Models;

var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.WeatherAppAPI>("weatherappapi");

builder.AddProject<Projects.WeatherFrontEndWeb>("weatherfrontendweb")
    .WithReference(api);

builder.Build().Run();
