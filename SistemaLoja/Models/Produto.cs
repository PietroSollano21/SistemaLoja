namespace Produtos.Models
{
public class Produto
{
    public string Nome {get; set;}
    public decimal Preco { get; set;}
    public int Quantidade { get; set; }
    public decimal desconto { get; set; }
    public Produto(string nome, decimal preco, int quantidade)
        {
            if(string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome não pode ser vazio.");
            }
            if(preco <= 0)
            {
                throw new ArgumentException("O preço deve ser maior que zero.");
            }
            if(quantidade < 0)
            {
                throw new ArgumentException("A quantidade não pode ser negativa.");
            }
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }
        public void AlterarPreco( decimal novoPreco)
{
    if (novoPreco > 0)
    {
        Preco = novoPreco;
        Console.WriteLine($"O preço do produto {Nome} foi alterado para {Preco:C2}");
    }
    else
    {
        Console.WriteLine("O preço não pode ser negativo.");
    }
}
    public bool Vender(int quantidade)
        {
            
           if(quantidade <= 0)
            {
                Console.WriteLine("A quantidade de venda deve ser maior que zero.");
                return false;
            }
            if(quantidade > Quantidade)
            {
                Console.WriteLine($"Não há estoque suficiente para vender {quantidade} unidades do produto {Nome}. Estoque disponível: {Quantidade}");
                return false;
            }
            Quantidade -= quantidade;
            Console.WriteLine("Venda realizada com sucesso!");
            return true;
        }
        public bool TemEstoque(int quantidadeCompra)
        {
            
            if(Quantidade < quantidadeCompra )
                    return false;
                return Quantidade >= quantidadeCompra;
        }
}
}