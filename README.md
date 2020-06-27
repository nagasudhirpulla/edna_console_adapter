This is the console data adapter for eDNA Historian C# API written in ASP.NET Core

## eDNA Historian API
The ddl for eDNA Historaian data fetching can be found at 
* https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Dependencies/GSF/EzDNAApiNet64.dll
* https://www.gridprotectionalliance.org/nightlybuilds/openXDA/Beta/Applications/openXDA/EzDNAApiNet.dll

## packaging asp.net core console app as a single exe file
By adding the following in the csproj file, we can pubish the asp.net core console app as a single exe file
```xml
<PropertyGroup>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <PublishSingleFile>true</PublishSingleFile>
    <PublishTrimmed>true</PublishTrimmed>
    <!--<PublishReadyToRun>true</PublishReadyToRun>-->
</PropertyGroup>
```
