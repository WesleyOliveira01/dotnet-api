using Microsoft.EntityFrameworkCore;

public static class EstudantesRoutes
{
    public static void MapEstudantesRoutes(this WebApplication app)
    {
        var estudanteGroup = app.MapGroup("/estudantes");

        app.MapGet("/", () => "Hello from students");

        estudanteGroup.MapGet(
            "",
            async (AppDbContext context) =>
            {
                var estudents = await context.estudantes.ToListAsync();
                if (estudents == null)
                    return Results.NotFound(new { Error = "Estudantes não cadastrados" });
                await context.SaveChangesAsync();
                return Results.Ok(estudents);
            }
        );

        estudanteGroup.MapPost(
            "",
            async (newEstudante req, AppDbContext context) =>
            {
                if (!bool.Parse(req.name))
                    return Results.BadRequest(new { Error = "O nome é obrigatório" });
                var novoEstudante = new Estudante(req.name);
                await context.estudantes.AddAsync(novoEstudante);
                await context.SaveChangesAsync();

                return Results.Ok(novoEstudante);
            }
        );

        estudanteGroup.MapPut(
            "{id}",
            async (Guid id, UpdateStudent req, AppDbContext context) =>
            {
                var estudante = await context.estudantes.FindAsync(id);
                if (estudante == null)
                    return Results.NotFound(new { Error = "Estudante não encontrado" });
                estudante.setName(req.nome);
                estudante.setActive(req.active);
                await context.SaveChangesAsync();
                return Results.Ok(estudante);
            }
        );

        estudanteGroup.MapDelete(
            "{id}",
            async (Guid id, AppDbContext context) =>
            {
                var findStudent = await context.estudantes.FindAsync(id);
                if (findStudent == null)
                    return Results.NotFound(new { Error = "Estudante não encontrado" });

                context.estudantes.Remove(findStudent);
                await context.SaveChangesAsync();
                return Results.Ok(new { Message = "Estudante deletado com sucesso" });
            }
        );
    }
}
