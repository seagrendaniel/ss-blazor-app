using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ssCRUDapp.Client;
using ssCRUDapp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ssCRUDapp.ServerAPI", client => 
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);

    Console.WriteLine("Base Address: -------------------- " + builder.HostEnvironment.BaseAddress);
})
.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ssCRUDapp.ServerAPI"));

builder.Services.AddScoped<ProductService>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
