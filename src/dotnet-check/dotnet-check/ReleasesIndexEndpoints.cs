using Microsoft.EntityFrameworkCore;
using CheckDotnetVersions.BackGroundServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using dotnet_check.Data;
namespace dotnet_check;

public static class ReleasesIndexEndpoints
{
    public static void MapReleasesIndexEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ReleasesIndex").WithTags(nameof(ReleasesIndex));

        group.MapGet("/", async (dotnet_checkContext db) =>
        {
            return await db.ReleasesIndex.ToListAsync();
        })
        .WithName("GetAllReleasesIndexs")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<ReleasesIndex>, NotFound>> (int id, dotnet_checkContext db) =>
        {
            return await db.ReleasesIndex.FindAsync(id)
                is ReleasesIndex model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetReleasesIndexById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, ReleasesIndex releasesIndex, dotnet_checkContext db) =>
        {
            var foundModel = await db.ReleasesIndex.FindAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }
            
            db.Update(releasesIndex);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateReleasesIndex")
        .WithOpenApi();

        group.MapPost("/", async (ReleasesIndex releasesIndex, dotnet_checkContext db) =>
        {
            db.ReleasesIndex.Add(releasesIndex);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ReleasesIndex/{releasesIndex.Id}",releasesIndex);
        })
        .WithName("CreateReleasesIndex")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok<ReleasesIndex>, NotFound>> (int id, dotnet_checkContext db) =>
        {
            if (await db.ReleasesIndex.FindAsync(id) is ReleasesIndex releasesIndex)
            {
                db.ReleasesIndex.Remove(releasesIndex);
                await db.SaveChangesAsync();
                return TypedResults.Ok(releasesIndex);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteReleasesIndex")
        .WithOpenApi();
    }
}
