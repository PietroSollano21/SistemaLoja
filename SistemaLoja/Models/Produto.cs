namespace Produtos.Models
{
public class Produto
{
    public string Nome {get; set;}
    public decimal Preco { get; set;}
    public int? Quantidade { get; set; }
    public decimal? desconto { get; set; }
}
}