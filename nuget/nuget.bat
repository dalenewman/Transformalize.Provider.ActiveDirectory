nuget pack Transformalize.Provider.ActiveDirectory.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Provider.ActiveDirectory.Autofac.nuspec -OutputDirectory "c:\temp\modules"

REM nuget push "c:\temp\modules\Transformalize.Provider.ActiveDirectory.0.5.0-beta.nupkg" -source https://api.nuget.org/v3/index.json
REM nuget push "c:\temp\modules\Transformalize.Provider.ActiveDirectory.Autofac.0.5.0-beta.nupkg" -source https://api.nuget.org/v3/index.json







