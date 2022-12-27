using Microsoft.EntityFrameworkCore;
public class BancoDeDados: DbContext{
    public BancoDeDados(DbContextOptions<BancoDeDados> options) : base(options){

    }
    public DbSet<Produto> Produtos {get; set;}

}