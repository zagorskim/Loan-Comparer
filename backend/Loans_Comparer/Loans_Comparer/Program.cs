using Loans_Comparer.Data;
using Loans_Comparer.Entites;
using Loans_Comparer.Helpers;
using Loans_Comparer.Services.EmailService;
using Loans_Comparer.Utilities;
using Loans_Comparer.Utilities.BankHandlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Azure.Identity;
using System;
using Loans_Comparer.Services;
using Loans_Comparer.Services.EmailHostedService;

var builder = WebApplication.CreateBuilder(args);

//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//var keyVaultEndpoint = new Uri(builder.Configuration["VaultName"]);
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LoanComparerDbContext>(options =>
    options.UseSqlServer(builder.Configuration["MyConnectionString"])); // //builder.Configuration.GetValue<string>("MyConnectionString")

builder.Services.AddOptions<ExternalServicesConfiguration>()
    .Bind(builder.Configuration.GetSection("ExternalServicesConfiguration"))
    .Validate(x => !string.IsNullOrWhiteSpace(x.TeachersCompanyApi), "TeacherBankApi is empty")
    .Validate(x => !string.IsNullOrWhiteSpace(x.OtherCompanyApi), "OtherTeamBankApi is empty")
    .Validate(x => !string.IsNullOrWhiteSpace(x.LocalCompanyApi), "LocalBankApi is empty");
builder.Services.AddHttpClient();
builder.Services.AddHostedService<QueuedHostedService>();
//builder.Services.AddSingleton<IBackgroundTaskQueue>(ctx =>
//{
//    if (!int.TryParse(builder.Configuration["QueueCapacity"], out var queueCapacity))
//        queueCapacity = 100;
//    return new BackgroundTaskQueue(queueCapacity);
//});
builder.Services.AddSingleton<IBackgroundOfferTasks>(new BackgroundOfferTasks());
builder.Services.AddTransient<IInquiryCreatingService, InquiryCreatingService>();
builder.Services.AddScoped<IOfferRequestingService, OfferRequestingService>();
builder.Services.AddTransient<ISendGridEmail, SendGridEmail>();
builder.Services.AddTransient<IBanksResolver, BanksResolver>();
builder.Services.AddTransient<IBankHandler, OtherBankHandler>();
builder.Services.AddTransient<IBankHandler, LocalBankHandler>();
builder.Services.AddTransient<IBankHandler, TeachersBankHanlder>();
builder.Services.AddTransient<IInquiryCreatingService, InquiryCreatingService>();
builder.Services.Configure<MessageSenderOptions>(builder.Configuration.GetSection("SendGrid"));

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<LoanComparerDbContext>()
                .AddDefaultTokenProviders();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddCookie()
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});
//.AddGoogle(googleOptions =>
//{

//    var googleAuth = builder.Configuration.GetSection("Authentication:Google");

//    googleOptions.ClientId = googleAuth["ClientId"];
//    googleOptions.ClientSecret = googleAuth["ClientSecret"];

//    //this function is get user google profile image
//    googleOptions.Scope.Add("profile");
//    googleOptions.SignInScheme = Microsoft.AspNetCore.Identity.IdentityConstants.ExternalScheme;
//});



var app = builder.Build();
app.UseSwagger();
app.UseCors(options => options.WithOrigins("http://localhost:3000/"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
