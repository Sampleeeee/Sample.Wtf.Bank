using Microsoft.AspNetCore.Mvc;
using Sample.Wtf.Bank.Entities;

namespace Sample.Wtf.Bank.Server;

public static class Authentication
{
    public static void MapAuthenticationEndpoints( this IEndpointRouteBuilder app )
    {
        app.MapPost( "/signup", CreateUser )
            .WithOpenApi();
        
        app.MapPost( "/login", Login )
            .WithOpenApi();
    }

    public static IResult CreateUser( DatabaseContext ctx, [FromBody] SignupArguments args )
    {
        var user = ctx.Users.Add( new User
        {
            Id = $"{Guid.NewGuid()}",
            Username = args.Username, 
            Password = args.Password,
            FirstName = args.FirstName,
            LastName = args.LastName,
            MiddleInitial = args.MiddleInitial,
        } );

        try
        {
            ctx.SaveChanges();
        }
        catch
        {
            return Results.Problem();
        }

        return Results.Ok( user );
    }
    
    public static IResult Login( DatabaseContext ctx, string username, string password )
    {
        if ( ctx.Users.FirstOrDefault( x => x.Username == username && x.Password == password ) is not User user )
            return Results.Unauthorized();

        return Results.Ok( user );
    }
    
    public record SignupArguments
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    
        public char? MiddleInitial { get; set; }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}