global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.SessionStorage;
using locustrace.Client;
using locustrace.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//adds new httpclient, specifies the baseaddress for Transfleet and injects it to ITokenService and TokenService
builder.Services.AddHttpClient<ITokenService, TokenService>(tf =>
{
    tf.BaseAddress = new Uri("https://test.transfleet.dev");
});

//adds new httpclient, specifies the baseaddress for Transfleet and injects it to IUserService and UserService
builder.Services.AddHttpClient<IUserService, UserService>(tf =>
{
    tf.BaseAddress = new Uri("https://test.transfleet.dev");
});

//adds new httpclient, specifies the baseaddress for Transfleet and injects it to IOrderService and OrderService
builder.Services.AddHttpClient<IOrderService, OrderService>(tf =>
{
    tf.BaseAddress = new Uri("https://test.transfleet.dev");
});

//adds new httpclient, specifies the baseaddress for Transfleet and injects it to IVehicleService and VehicleService
builder.Services.AddHttpClient<IVehicleService, VehicleService>(tf =>
{
    tf.BaseAddress = new Uri("https://test.transfleet.dev");
});

//adds new httpclient, specifies the baseaddress for Transfleet and injects it to IConfigService and ConfigService
builder.Services.AddHttpClient<IConfigService, ConfigService>(tf =>
{
    tf.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

//adds functionality for session handling
builder.Services.AddBlazoredSessionStorage();

//creates dependency injection
builder.Services.AddScoped<ISessionHandlerService, SessionHandlerService>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();


