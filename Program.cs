using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BancoDeDados>(
    options => options.UseSqlite("Data Source=BancoDeDados.db")
);
var app = builder.Build();

app.MapPost("/produtos", (Produto produto, BancoDeDados bd) => {

    bd.Add(produto);
    bd.SaveChangesAsync();
    return Results.Ok(produto);
});

app.MapGet("/allprodutos", (BancoDeDados bd) => bd.Produtos.ToListAsync());
app.MapGet("/allproduto", async (BancoDeDados bd) => {
    List<Produto> produtos = new List<Produto>();
    produtos = await bd.Produtos.ToListAsync();
    return Results.Ok(produtos[0]);
});

app.MapPut("/updateproduto/{id}", (Produto produto, int Id, BancoDeDados bd) => {

    bd.Update(produto);
    bd.SaveChangesAsync();
    return Results.Ok(produto);
});


app.MapDelete("/removeproduto/{id}", async (int id, BancoDeDados bd) => {

    Produto p = await bd.Produtos.FirstOrDefaultAsync(p => p.Id == id);
    bd.Remove(p);
    bd.SaveChangesAsync();
    return Results.Ok(p);
});

app.Run();
