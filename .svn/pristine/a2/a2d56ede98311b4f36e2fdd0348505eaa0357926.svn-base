using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Migrations.DailyLog.Migrations;

namespace Migrations.DailyLog
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var items = input?.Split(" ");
            if (items != null)
            {
                string migrationChoice = items[0];
                var serviceProvider = CreateServices();

                // Put the database update into a scope to ensure
                // that all resources will be disposed.
                using (var scope = serviceProvider.CreateScope())
                {
                    //DatabaseCreator.EnsureDatabase(Tables.DatabaseName);

                    if (migrationChoice != null && migrationChoice.ToLower().Equals("up"))
                    {
                        UpdateDatabase(scope.ServiceProvider);
                    }

                    if (migrationChoice != null && migrationChoice.ToLower().Equals("down"))
                    {
                        if (items.Length > 1)
                        {
                            var version = Convert.ToInt64(items[1]);
                            if (version > -1)
                            {
                                RollbackDatabase(scope.ServiceProvider, version);
                            }
                        }
                    }
                }
            }
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLServer support to FluentMigrator
                    .AddPostgres()
                    // Set the connection string
                    .WithGlobalConnectionString("Server=127.0.0.1;Database=logsSystem;Port=5432;User Id=postgres;Password=1234567;")
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(_004_project).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }

        private static void RollbackDatabase(IServiceProvider serviceProvider, long rollbackVersion)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateDown(rollbackVersion);
        }

    }
}