# NgDesk
NgDesk is a nuget package which serves your Angular App as a Desktop application using WebView2 (Winforms or WPF)

# Usage

Currently there are two use cases implemented:
1. Serve your app from a folder
2. Serve your app from embedded resources

All you have to do is

1. `Install-Package NgDesk -Version 1.0.0`
2. Add to your `.csproj` file

```
<PropertyGroup>
  <NgDist> $$$folder$$$ </NgDist>
</PropertyGroup>
```

Use case 1: If you want to serve your app from a folder then `$$$folder$$$` has to be the folder of your Ng app relative to your running app.

Use case 2: If you want to serve your app from an embedded resource then `$$$folder$$$` has to be the folder of your Ng app relative to your project file
and your Ng app must be built before you build your C# app.

In your C# app you serve the Ng app (serve from folder) via
```
var server = NgDesk.Factory.GetServerUsingFilePath();
Task.Factory.StartNew(async() => await server.ServeAsync("http://localhost:4444/"));
```

or (serve as embedded resource) via
```
var server = NgDesk.Factory.GetServerUsingEmbeddedResources();
Task.Factory.StartNew(async() => await server.ServeAsync("http://localhost:4444/"));
```

There are also samples provided.
