public class Produto{

    public int Id {get; set;}
    public string? Nome {get; set;}
    public string? Descricao {get; set;}
    public double? Preco {get; set;}
    public Produto(){
        
    }
    public Produto(string? nome, string? descricao, double? preco)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }
    
    public Produto(int id, string? nome, string? descricao, double? preco) : this(nome, descricao, preco)
    {
        Id = id;
    }
    
}