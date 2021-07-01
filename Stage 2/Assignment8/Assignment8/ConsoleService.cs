using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

public class ConsoleService : IHostedService
{
    private readonly IHostApplicationLifetime _appLifetime; 
    private readonly CRMContext _dbContext;
    public ConsoleService(
       CRMContext dbContext,
       IHostApplicationLifetime appLifetime) {
        _dbContext = dbContext;
        _appLifetime = appLifetime;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {

        _appLifetime.ApplicationStarted.Register(() => {
            Task.Run(async () => { 
                try
                {
                    Console.WriteLine("hello...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {

                    _appLifetime.StopApplication();
                }
            });
        });

        return Task.CompletedTask;
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
