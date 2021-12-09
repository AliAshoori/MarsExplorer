using System;
using System.Threading.Tasks;
using MarsExplorer.Commands;
using MarsExplorer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MarsExplorer
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            Console.WriteLine("Please run the RobotInstructionCommandHandlerTests for testing, thanks.");

            return host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services
                        .AddScoped<ICommandHandler<RobotInstructionCommand, string>, RobotInstructionCommandHandler>();

                    services.AddScoped<IInstructionServicesCreator, InstructionServicesCreator>();
                    services.AddScoped<IInstructionServiceCreator, MoveForwardInstructionServiceCreator>();
                    services.AddScoped<IInstructionServiceCreator, RotateRightInstructionServiceCreator>();
                    services.AddScoped<IInstructionServiceCreator, RotateLeftInstructionServiceCreator>();
                });
        }
    }
}
