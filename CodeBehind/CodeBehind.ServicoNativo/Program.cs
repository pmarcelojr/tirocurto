using CodeBehind.ServicoNativo;
using CodeBehind.ServicoNativo.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<WorkerHost>();
    })
    .Build();

await host.RunAsync();
