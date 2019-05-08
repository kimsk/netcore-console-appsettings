// Learn more about F# at http://fsharp.org

open System
open Microsoft.Extensions.Configuration
open System.IO

[<EntryPoint>]
let main argv =
    let builder = 
      ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)

    let configuration = builder.Build()

    let setting = configuration.GetSection("test").["test"]
    printfn "%s" setting
    0