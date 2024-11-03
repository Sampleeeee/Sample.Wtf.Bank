using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sample.Wtf.Bank.Entities;
using Sample.Wtf.Bank.Entities.Api;

namespace Sample.Wtf.Bank.Server;

public static class Admin
{
    public static void MapAdminEndpoints( this IEndpointRouteBuilder app )
    {
        app.MapGet( "/getallusers", GetAllUsers )
            .WithOpenApi();
        
        app.MapGet( "/getallaccounts", GetAllAccounts )
            .WithOpenApi();

        app.MapPost( "/updateuser", UpdateUserAsync )
            .WithOpenApi();
        
        app.MapPost( "/createuser", CreateUser )
            .WithOpenApi();
    }

    private static IResult GetAllUsers( DatabaseContext ctx )
    {
        var list = new List<UserResult>();
        
        foreach ( var result in ctx.Users ) 
            list.Add( new UserResult( result ) );

        return Results.Ok( list );
    }

    private static async Task<IResult> UpdateUserAsync( DatabaseContext ctx, [FromBody] UpdateUserArguments args )
    {
        var user = ctx.Users.FirstOrDefault( x => x.Id == args.Id );
        if ( user is null )
            return Results.Problem( "User not found." );
        
        user.FirstName = args.FirstName ?? user.FirstName;
        user.LastName = args.LastName ?? user.LastName;
        user.MiddleInitial = args.MiddleInitial ?? user.MiddleInitial;
        user.Username = args.Username ?? user.Username;
        user.Password = args.Password ?? user.Password;
        
        // TODO user.accounts

        await ctx.SaveChangesAsync();
        
        return Results.Ok();
    }
    
    private static IResult GetAllAccounts( DatabaseContext ctx ) =>
        Results.Ok( ctx.Accounts.ToList() );
    
    private static IResult CreateUser( DatabaseContext ctx, [FromBody] CreateUserArguments args )
    {
        Console.WriteLine( args.FirstName );
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

        return Results.Ok( new UserResult( user.Entity ) );
    }
}