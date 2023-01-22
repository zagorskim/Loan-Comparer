using Azure.Storage.Blobs;
using BankAPI.Data;
using BankAPI.FileManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

string connectionString = Environment.GetEnvironmentVariable("DBCONNECTIONSTRING");

// Add services to the container.

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
            Title="Bank API", 
            Version = "v1",
            Description= "An ASP .NET Web API for a bank, made for .NET Web Programming class. It allows to post inquiries for loans and creates offers for them.",
            Contact = new OpenApiContact
            {
                Name="Our Bank",
                Email="dont@email.me",
                Url= new Uri("https://example.com/contact")
            }

        });

        //generate the xml docs that'll drive the swagger docs
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        c.IncludeXmlComments(xmlPath);

        //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        //{
        //    Description = "OAuth2.0 which uses AuthorizationCode flow",
        //    Name = "oauth2.0",
        //    Type = SecuritySchemeType.OAuth2,
        //    Flows = new OpenApiOAuthFlows
        //    {
        //        AuthorizationCode = new OpenApiOAuthFlow
        //        {
        //            AuthorizationUrl = new Uri(builder.Configuration["SwaggerAzureAD:AuthorizationUrl"]),
        //            TokenUrl = new Uri(builder.Configuration["SwaggerAzureAD:TokenUrl"]),
        //            Scopes = new Dictionary<string, string>
        //            {
        //                {builder.Configuration["SwaggerAzureAD:Scope"],"Access API as User" }
        //            }
        //        }
        //    }
        //});
        //c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //{
        //    {
        //        new OpenApiSecurityScheme
        //        {
        //            Reference = new OpenApiReference{Type=ReferenceType.SecurityScheme,Id="oauth2" }
        //        },
        //        new[]{builder.Configuration["SwaggerAzureAD:Scope"]}
        //    }
        //});
    }
    );

builder.Services.AddDbContext<BankAPIDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionString"]));
//builder.Services.AddDbContext<BankAPIDbContext>(options => options.UseSqlServer(connectionString:builder.Configuration["DBCONNECTIONSTRING"]));
builder.Services.AddControllersWithViews(options => { options.SuppressAsyncSuffixInActionNames = false; });

//blob
builder.Services.AddScoped(_ => {
    return new BlobServiceClient(builder.Configuration["ConnectionStrings:AzureBlobStorage"]);
});
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["ConnectionStrings:AzureBlobStorage:blob"], preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["ConnectionStrings:AzureBlobStorage:queue"], preferMsi: true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.OAuthClientId(builder.Configuration["SwaggerAzureAD:ClientId"]);
    c.OAuthUsePkce(); //required for authorization code flow
    c.OAuthScopeSeparator(" ");
});
    IdentityModelEventSource.ShowPII = true;
}
//if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) { app.UseSwagger(); app.UseSwaggerUI(); }

app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();



app.Run();
