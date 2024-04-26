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

### Run mode
While the main code sample is in `App.cs`, you'll find an alternative version in `AppRunMode.cs` which allows for a continuous stream of measurement outputs.

To run it, you'll want to switch the **Startup object**:
- Open the project's properties _(right-click on `sample-csharp-cli.csproj` > Properties)_
- In _Application > General_, open the dropdown under _Startup object_ and instead of `App`, select `AppRunMode`.

From there, you can use the same instructions as above ⤴️ to run it.


## Sample output

### Normal mode
<img src="https://github.com/Dracaltech/sample-csharp-cli/assets/1357711/655893a6-3305-4044-8285-d4cbdf418ac4" width=400 />

```
Temperature (C): 99.39
RH......... (%): 21.5
Pressure. (kPa): 54.16
Temperature (F): 210.90201

C:\dev\dracal\sample-csharp-cli\bin\Debug\net8.0\sample-csharp-cli.exe (process 36996) exited with code 0.
To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
Press any key to close this window . . .
```

### Run mode
<img src="https://github.com/Dracaltech/sample-csharp-cli/assets/1357711/10f1118b-5c9c-444b-905a-95b6dd17c6be" width=400 />

```
2024-04-26 14:27:21:
Temperature (C): 100.44
RH......... (%): 22.56
Pressure. (kPa): 45.06
Temperature (F): 212.792

2024-04-26 14:27:22:
Temperature (C): 100.44
RH......... (%): 22.59
Pressure. (kPa): 45.08
Temperature (F): 212.792

C:\dev\dracal\sample-csharp-cli\bin\Debug\net8.0\sample-csharp-cli.exe (process 22780) exited with code -1073741510.
To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
Press any key to close this window . . .
```
