using static System.Console;

WriteLine("Digite o nome do arquivo");
var nome = ReadLine();

nome = LimparNome(nome);

var path1 = Path.Combine(Environment.CurrentDirectory, $"{nome}.txt");
var path2 = Path.Combine(Environment.CurrentDirectory, "teste2.txt");

CriarArquivos(path1, path2);

WriteLine("Tecle Enter para finalizar.");
ReadLine();

static void CriarArquivos(string path1, string path2)
{
    //var path = Environment.CurrentDirectory + "\\teste.txt"; --Outra forma de indicar caminho.
    //var path = Path.Combine(@""C:\temp,"teste.txt"); --Caso queira criar em uma pasta diferente da aplicação.

    try
    {
        var sw = File.CreateText(path1);
        sw.WriteLine("Linha 1");
        sw.WriteLine("Linha 2");
        sw.WriteLine("Linha 3");
        sw.WriteLine("Linha 4");
        sw.WriteLine("Linha 5");

        //Cada linha de texto criada vai ficar armazenado na memória, Depois que faz o Flush ele passa essa informação para o arquivo. Então, sempre ir dando fush na criação do arquivo para não sobrecarregar memória.
        sw.Flush();
    }
    catch
    {

        WriteLine("O nome do Arquivo está inválido. Não utilize caracteres especiais.");
    }


    //colocando a syntaxe do using ele acessa a interface usada pela StreamWriter chamada IDisposable que força uma finalização então ele usa o flush de manteira automatica.
    using (var sw2 = File.CreateText(path2))
    {
        sw2.WriteLine("Linha 6");
        sw2.WriteLine("Linha 7");
    }
}

static string LimparNome(string nome)
{
    foreach (var character in Path.GetInvalidFileNameChars()) //o método do Path retorna uma array com caracteres inválidos.
    {
        nome = nome.Replace(character, '-'); //por algum motivo não funciona com aspas duplas.
    }
    return nome;
}