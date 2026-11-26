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
    Dictionary<string, decimal> precos = new Dictionary<string, decimal>();
    foreach(Produto produto in produtos)
    {
        precos[produto.Nome] = produto.Preco;
    }

    if (produtos.Count == 0)
    {
        Console.WriteLine("Nenhum produto cadastrado.");
    }
    else
    {
        decimal somaPrecos = 0;
        Console.WriteLine("Produtos cadastrados:");
        foreach(KeyValuePair<string, decimal> produto in precos)
        {
            Console.WriteLine($"{produto.Key} | {produto.Value:C2}");
            somaPrecos += produto.Value;
        }
        Console.WriteLine($"Soma dos preços : {somaPrecos:C2}");
        Console.WriteLine($"Total de produtos: {precos.Count}");
    }
}
static decimal CalcularTotal(decimal preco, int quantidade)
{
    return preco * quantidade;
}
static Produto CriarProduto()
{
Console.Write("Informe o nome do produto:");
string nomeProduto = Console.ReadLine();

while (string.IsNullOrWhiteSpace(nomeProduto))
{
    Console.WriteLine("O nome do produto não pode ficar vazio!");
    Console.Write("Informe o nome do produto novamente:");
    nomeProduto = Console.ReadLine();
}
Console.Write("Informe o preço do produto:");
decimal precoProduto;
 
while (!decimal.TryParse(Console.ReadLine(), out precoProduto) || precoProduto <= 0)
{
    Console.WriteLine("O preço do produto não pode ser negativo!");
    Console.Write("Informe o preço do produto novamente:");
}
Console.Write("Informe a quantidade do produto:");
int quantidadeProduto;
 
while (!int.TryParse(Console.ReadLine(), out quantidadeProduto) || quantidadeProduto < 0)
{
    Console.WriteLine("A quantidade do produto não pode ser negativa!");
    Console.Write("Informe a quantidade do produto novamente:");
}
decimal valorTotal = CalcularTotal(precoProduto, quantidadeProduto);
Console.WriteLine($"O produto {nomeProduto} foi registrado");
return new Produto(nomeProduto, precoProduto, quantidadeProduto);
}
static void RealizarCompra(List<Produto> produtos)
{
    Console.Write("Qual produto deseja comprar? (Digite o número correspondente): ");
    int produtoEscolhido;
    while (!int.TryParse(Console.ReadLine(), out produtoEscolhido) || produtoEscolhido < 1 || produtoEscolhido > produtos.Count)
    {
        Console.Write("Produto inválido. Escolha novamente: ");
    }
    Console.Write("Quantas unidades deseja comprar?: ");
            int quantidadeCompra;
            while (!int.TryParse(Console.ReadLine(), out quantidadeCompra) || !produtos[produtoEscolhido - 1].TemEstoque(quantidadeCompra))
{
    Console.Write("Quantidade inválida. Digite novamente: ");
}
    bool vendaRealizada = produtos[produtoEscolhido - 1].Vender(quantidadeCompra);
    if (vendaRealizada)
    {
        decimal totalCompra = produtos[produtoEscolhido - 1].Preco * quantidadeCompra;
        Console.WriteLine($"Produto: {produtos[produtoEscolhido - 1].Nome}");
        Console.WriteLine($"Quantidade: {quantidadeCompra}");
        Console.WriteLine($"Total: {totalCompra:C2}");
    }
    else
    {
        Console.WriteLine("Estoque insuficiente.");
    }
} 
static Produto TestarCadastro()
{
    try
    {
        string nome = "abc";
        decimal preco = 55;
        int quantidade = 10;
        Produto produto = new Produto(nome, preco, quantidade);
        return produto;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao testar cadastro: {ex.Message}");
        return new Produto("", 0, 0);
    }
    finally
    {
        Console.WriteLine("Teste Finalizado");
    }
}
static void BuscarProduto(List<Produto> produtos)
{
    Console.Write("Qual produto deseja buscar?: ");
    string nomeBusca = Console.ReadLine();
    List<Produto> produtoEncontrado = produtos.Where(p => p.Nome.Contains(nomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();
    if (produtoEncontrado.Count > 0)
    {
        foreach(Produto produto in produtoEncontrado)
        {
        Console.WriteLine($"Produtos encontrados: {produto.Nome} | {produto.Preco:C2} | {produto.Quantidade} disponível(eis)");
        }  
    }
    else
    {
        Console.WriteLine("Nenhum produto encontrado.");
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
Produto produto = CriarProduto();
produtos.Add(produto);
break;

case 2:
if(produtos.Count == 0)
{
    Console.WriteLine("Nenhum produto cadastrado");
}
else
{
    BuscarProduto(produtos);
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
    RealizarCompra(produtos);
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
double[] notas = { 7.5, 8.0, 6.5, 9.0, 10.0 };
double soma = 0;
Console.WriteLine($"Notas: {string.Join(", ", notas)}");
foreach (double nota in notas)
{
    soma += nota;
}
double média = soma / notas.Length;
Console.WriteLine($"Soma: {soma}");
Console.WriteLine($"Média: {média:F2}");
Console.WriteLine("Notas:");
foreach (double nota in notas)
{
    Console.WriteLine($"- {nota:F2}");
}

