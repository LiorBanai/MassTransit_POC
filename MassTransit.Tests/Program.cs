
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PipeBaseServices;
using PipeBaseServices.MassTransit;

namespace MassTransit.Tests
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // T customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<MainForm>();
                    services.AddSingleton<IGenericDataProducer<SystemEvent>, MTSystemEventProducer>();
                    MTSystemEventConsumer seConsumer = new MTSystemEventConsumer();
                    services.AddSingleton<ISystemEventConsumer>(_ => seConsumer);
                    services.AddMassTransit(x =>
                    {
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host("localhost", "/", h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                                h.ConfigureBatchPublish(b => b.Enabled = true);
                            });

                            cfg.ReceiveEndpoint(Guid.NewGuid().ToString(),
                                c =>
                                {
                                    c.AutoDelete = true;
                                    c.Instance(seConsumer);
                                });

                            cfg.ConfigureEndpoints(context);

                        });
                    });
                });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var mainForm = services.GetRequiredService<MainForm>();
                    var bus = services.GetRequiredService<IBusControl>();
                    bus.Start();
                    Application.Run(mainForm);
                }
                catch (Exception e)
                {
                    //nothing
                }
            }
        }

    }
}
