Meziantou.AspNetCore.BundleTagHelpers
======

When you use the Visual Studio extension `BundleMinifier` ([download](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.BundlerMinifier)), 
you have to declare the bundles in the `bundleconfig.json` file (input files, output file and minification options).
The idea of this project is to generate the `script` and `link` tags by using the list of bundles define in the `bundleconfig.json` file.
So, instead of writing a code similar to (from the ASP.NET Core template):

```
<environment names="Development">
    <link rel="stylesheet" href="~/css/site.css" />
</environment>
<environment names="Staging,Production">
    <link rel="stylesheet" href="~/css/site.min.css" asp-append-version="true" />
</environment>
```

You only write this:

```
<bundle name="wwwroot/css/site.min.css" />
```

- In production, it uses the minified file and appends the version in the query string (same behavior as `asp-append-version`).
- In development, it uses all input files and does not append version.

*Note: This goal of this project is not to minify files, but only to generate the `script` and link `tags`. The BundleMinifier extension does generate min files.*

# How to use

- Install NuGet package `Meziantou.AspNetCore.BundleTagHelpers`
- Register the tag helpers:

```
@addTagHelper *, Meziantou.AspNetCore.BundleTagHelpers
```

- Use the tag helper

```
<bundle name="wwwroot/js/site.min.js" />
<bundle name="wwwroot/css/site.min.css" />
```

- (optional) Edit the `Startup.cs` file:

```
//using Meziantou.AspNetCore.BundleTagHelpers;

public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddBundles(options =>
    {
        options.UseMinifiedFiles = false;
        options.AppendVersion = false;
    });
}
```