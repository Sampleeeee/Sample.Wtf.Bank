using Microsoft.AspNetCore.Mvc;
using Sample.Wtf.Bank.Entities;
using Sample.Wtf.Bank.Entities.Api;

namespace Sample.Wtf.Bank.Server;

public static class Authentication
{
    public static void MapAuthenticationEndpoints( this IEndpointRouteBuilder app )
    {
        // app.MapPost( "/signup", CreateUser )
        //     .WithOpenApi();
        
        app.MapPost( "/login", Login )
            .WithOpenApi();
    }

    
    
    public static IResult Login( DatabaseContext ctx, [FromBody] LoginArguments args )
    {
        if ( ctx.Users.FirstOrDefault( x => x.Username == args.Username && x.Password == args.Password ) is not User user )
            return Results.Unauthorized();

        return Results.Ok( user );
    }
}