using CommunityEventPlanner.Client;
using CommunityEventPlanner.Client.Services;
using CommunityEventPlanner.Client.Services.Interfaces;
using CommunityEventPlanner.Client.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Constants.BaseUrl) });
    builder.Services.AddScoped<IBaseService, BaseService>();
    builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<CustomAuthStateProvider>();
    builder.Services.AddScoped<IEventService, EventService>();

    builder.Services.AddOptions();
    builder.Services.AddAuthorizationCore();
    builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

    builder.Logging.SetMinimumLevel(LogLevel.Debug);

    await builder.Build().RunAsync();


