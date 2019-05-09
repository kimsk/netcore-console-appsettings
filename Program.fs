open System
open System.IO
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection

[<EntryPoint>]
let main argv =
    let builder = 
      ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .AddEnvironmentVariables()

    let configuration = builder.Build()

    let serviceCollection =
      ServiceCollection()
        .AddSingleton<IConfigurationRoot>(configuration)
        .BuildServiceProvider()
      
    let c = serviceCollection.GetService<IConfigurationRoot>()

    let setting = c.GetSection("test").["test"]
    let environment = c.GetSection("ASPNETCORE_ENVIRONMENT").Value
    printfn "%s" setting
    printfn "%s" environment

    // get environment variable using System.Environment
    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
    |> printfn "%s"

    0