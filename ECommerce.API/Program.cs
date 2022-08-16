using Business.Abstract;
using Business.Concrete;
using Business.Helper.AutoMapperProfiles;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;
using System.Text;
//[assembly: InternalsVisibleTo("TestProject")]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ExampleDb")));
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authendication with Jwt Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Id ="Bearer",
                Type = ReferenceType.SecurityScheme
            }
        },
                    new List<string>()
}
    });
});
builder.Services.AddCors();
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Token:SigninKey"));

//services.Configure<Token>(Configuration.GetSection("Token"));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    //var key = Encoding.ASCII.GetBytes(Configuration["Token:SigningKey"]);

    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey((key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryManager>();
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

builder.Services.AddAutoMapper(typeof(ProductCategoryProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CustomProductProfile).Assembly);

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductCategoryDal, EfProductCategoryDal>();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

