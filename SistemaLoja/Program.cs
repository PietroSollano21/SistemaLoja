using System.Globalization;
using Produtos.Models;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
List<Produto> produtos = new List<Produto>();
bool continuar = true;
 static void ExibirMenu()
{
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Cadastrar Produto");
    Console.WriteLine("2 - Listar Produtos");
    Console.WriteLine("3 - Sair");
}
static void ExibirProdutos(List<Produto> produtos)
{
    if (produtos.Count == 0)
    {
        Console.WriteLine("Nenhum produto cadastrado.");
    }
    else
    {
        Console.WriteLine("Produtos cadastrados:");
        for (int i = 0; i < produtos.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {produtos[i].Nome} | {produtos[i].Preco:C2} | {produtos[i].Quantidade} disponível(eis)");
        }
    }
}
static decimal CalcularTotal(decimal preco, int quantidade)
{
    return preco * quantidade;
}
static Produto CriarProduto(string nome, decimal preco, int quantidade)
{
    Produto produto = new Produto();
    produto.Nome = nome;
    produto.Preco = preco;
    produto.Quantidade = quantidade;
    return produto;
}
static void RealizarCompra(List<Produto> produtos)
{
    if (produtos.Count == 0)
    {
        Console.WriteLine("Nenhum produto cadastrado.");
        return;
    }

    Console.WriteLine("Produtos cadastrados:");
    ExibirProdutos(produtos);

    Console.Write("Qual produto deseja comprar? (Digite o número correspondente): ");
    int produtoEscolhido;
    while (!int.TryParse(Console.ReadLine(), out produtoEscolhido) || produtoEscolhido < 1 || produtoEscolhido > produtos.Count)
    {
        Console.Write("Produto inválido. Escolha novamente: ");
    }

    Produto escolhaProduto = produtos[produtoEscolhido - 1];

    Console.Write("Quantas unidades deseja comprar?: ");
    int quantidadeCompra;
    while (!int.TryParse(Console.ReadLine(), out quantidadeCompra) || quantidadeCompra <= 0)
    {
        Console.Write("Quantidade inválida. Digite novamente: ");
    }

    if (quantidadeCompra <= escolhaProduto.Quantidade)
    {
        decimal totalCompra = CalcularTotal(escolhaProduto.Preco, quantidadeCompra);
        escolhaProduto.Quantidade -= quantidadeCompra;
        Console.WriteLine($"Produto: {escolhaProduto.Nome}");
        Console.WriteLine($"Quantidade: {quantidadeCompra}");
        Console.WriteLine($"Total: {totalCompra:C2}");
    }
    else
    {
        Console.WriteLine("Estoque insuficiente.");
    }
} 
while(continuar)
{
    ExibirMenu();
int resposta;
while(!int.TryParse(Console.ReadLine(), out resposta) || resposta <= 0 || resposta > 3)
{
    Console.Write("Valor inválido, insira um valor entre 1 e 3:");
}
switch(resposta)
{
    case 1:
Produto produto = CriarProduto("", 0, 0);

Console.Write("Informe o nome do produto:");
string nomeProduto = Console.ReadLine();

while (string.IsNullOrWhiteSpace(nomeProduto))
{
    Console.WriteLine("O nome do produto não pode ficar vazio!");
    Console.Write("Informe o nome do produto novamente:");
    nomeProduto = Console.ReadLine();
}
produto.Nome = nomeProduto;
Console.Write("Informe o preço do produto:");
decimal precoProduto;
 
while (!decimal.TryParse(Console.ReadLine(), out precoProduto) || precoProduto <= 0)
{
    Console.WriteLine("O preço do produto não pode ser negativo!");
    Console.Write("Informe o preço do produto novamente:");
}
produto.Preco = precoProduto;
Console.Write("Informe a quantidade do produto:");
int quantidadeProduto;
 
while (!int.TryParse(Console.ReadLine(), out quantidadeProduto) || quantidadeProduto < 0)
{
    Console.WriteLine("A quantidade do produto não pode ser negativa!");
    Console.Write("Informe a quantidade do produto novamente:");
}
produto.Quantidade = quantidadeProduto;
decimal valorTotal = CalcularTotal(precoProduto, quantidadeProduto);
Console.Write("Há desconto? (S/N):");
string respostaDesconto = Console.ReadLine();
while (respostaDesconto.ToUpper() != "S" && respostaDesconto.ToUpper() != "N")
{
    Console.WriteLine("Resposta inválida. Digite S para sim ou N para não.");
    Console.Write("Há desconto? (S/N):");
    respostaDesconto = Console.ReadLine();
}
if (respostaDesconto.ToUpper() == "S")
{
    Console.Write("Informe o desconto: ");
    decimal desconto;
    while (!decimal.TryParse(Console.ReadLine(), out desconto) || desconto < 0 || desconto > 100)
    {
        Console.Write("Desconto inválido. O desconto deve estar entre 0 e 100 \n informe novamente o desconto:");
    }
    decimal valorComDesconto = valorTotal * (desconto / 100);
    decimal valorfinal = valorTotal - valorComDesconto;
    Console.WriteLine($"O produto {nomeProduto} foi registrado");
}
if (respostaDesconto.ToUpper() == "N")
{
Console.WriteLine($"O produto {nomeProduto} foi registrado");
}
produtos.Add(produto);
break;

case 2:
if(produtos.Count == 0)
{
    Console.WriteLine("Nenhum produto cadastrado");
}
else
{
Console.WriteLine("Podutos Cadastrados:");
ExibirProdutos(produtos);
Console.Write("Deseja Realizar uma compra? S/N:");
string respostaCompra = Console.ReadLine();
while (respostaCompra.ToUpper() != "S" && respostaCompra.ToUpper() != "N")
{
    Console.WriteLine("Resposta inválida. Digite S para sim ou N para não.");
    Console.Write("Irá comprar? (S/N):");
    respostaCompra = Console.ReadLine();
}
if(respostaCompra.ToUpper() == "S")
{
    Console.Write("Qual produto irá comprar? (selecione sua numeração):");
    int produtoEscolhido;
    while(!int.TryParse(Console.ReadLine(), out produtoEscolhido) || produtoEscolhido < 1 || produtoEscolhido > produtos.Count)
    {
        Console.Write("Produto inválido.Escolha Novamente:");
    }
    int quantidadeCompra;
    Console.Write("Quantas unidades deseja comprar?:");
    while(!int.TryParse(Console.ReadLine(), out quantidadeCompra) || quantidadeCompra <= 0)
    {
        Console.Write("Quantidade inválida. Digite novamente: ");
    }
    if(quantidadeCompra <= produtos[produtoEscolhido - 1].Quantidade)
    {
        decimal totalCompra = CalcularTotal(produtos[produtoEscolhido - 1].Preco, quantidadeCompra);
        produtos[produtoEscolhido - 1].Quantidade -= quantidadeCompra;
        Console.WriteLine($"Produto: {produtos[produtoEscolhido - 1].Nome}");
        Console.WriteLine($"Quantidade: {quantidadeCompra}");
        Console.WriteLine($"Total {totalCompra:C2}");
    }
    else
    {
        Console.WriteLine("Estoque insuficiente");
    }
    Produto escolhaProduto = produtos[produtoEscolhido - 1];
    Console.WriteLine($"Você escolheu: {escolhaProduto.Nome}");
}
else
{
        Console.WriteLine("Saindo...");
}
}
break;
    case 3:

 Console.WriteLine("Saindo...");
 continuar = false;
 break;
default:
    Console.WriteLine("Opção inválida");
    break;
}
}

