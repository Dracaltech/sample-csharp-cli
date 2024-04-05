# sample-csharp-cli
Dracal // SDK code sample for C# on CLI

## Assumptions

Running this repository requires you to have installed:
- .NET (version >= `8.0`)
- Visual Studio (version >= 2022)
- DracalView (version >= `3.2.x`)
  - Specifically, `dracal-usb-get` needs to be accessible from your `PATH` environment variable (more info in the [documentation how-to](https://www.dracal.com/en/programmers_howto/#dracal-usb-get)).

Script may need to be adjusted depending on your instrument's # of outputs _(currently assumed: 3 outputs)_. See script comments for details.


## Simple usage

Run by
- Using the **Play** button (Visual Studio)
- Build and run using the command line:

```
dotnet run sample-csharp-cli.sln
```



## Sample output
<img src="https://github.com/Dracaltech/sample-csharp-cli/assets/1357711/f7563bfc-8fb6-4a8d-9943-e891719cf14d" width=400 />

```
Pressure. (kPa): 101.23
Temperature (C): 20.72
RH......... (%): 56.95
Temperature (F): 69.296

C:\dev\dracal\sample-csharp-cli\bin\Debug\net8.0\sample-csharp-cli.exe (process 6720) exited with code 0.
To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
Press any key to close this window . . .
```
