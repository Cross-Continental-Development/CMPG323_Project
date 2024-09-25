using CCD_SHARE2TEACH.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
/*
// Add services to the container rolesDBContext
builder.Services.AddDbContext<RolesDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString")));*/

// Add services to the container rolesDBContext
builder.Services.AddDbContext<RolesDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("ConnString")));

// Add services to the container TAGSDBContext
builder.Services.AddDbContext<TAGSDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("ConnString")));

// Add services to the container gardeDBContext
builder.Services.AddDbContext<GradeDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("ConnString")));

// Add services to the container ratingsDBContext
builder.Services.AddDbContext<RatingsDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("ConnString")));

// Add services to the container usersDBContext
builder.Services.AddDbContext<UsersDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("ConnString")));

// Add services to the container documentsDBContext
builder.Services.AddDbContext<DocumentsDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("ConnString")));

// Add services to the container analyticsDBContext
builder.Services.AddDbContext<AnalyticsDBContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("ConnString")));

// Add services to the container faqDBContext
builder.Services.AddDbContext<FAQDBContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("ConnString")));

// Add services to the container moderationsDBContext
builder.Services.AddDbContext<ModerationsDBContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("ConnString")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
