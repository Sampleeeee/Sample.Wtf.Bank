using Microsoft.EntityFrameworkCore;
using Sample.Wtf.Bank.Server;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddCors( options =>
{
    options.AddPolicy( "BlazorClientPolicy", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    } );
} );

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>( options => options.UseSqlite( builder.Configuration.GetConnectionString("DefaultConnection" ) ) );

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors( "BlazorClientPolicy" );

app.MapAuthenticationEndpoints();
app.MapAdminEndpoints();

app.Run();
