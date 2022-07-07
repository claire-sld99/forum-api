using forum_api.DataAccess.DataObjects;
using forum_api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<ITopicRepository, TopicRepository>();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddEntityFrameworkMySql().AddDbContext<forumdbContext>((option) =>
{
    option.UseMySql(builder.Configuration.GetConnectionString("db"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"),
        mySqlOptionsAction: mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("MyPolicy");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
