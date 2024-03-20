using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Anagramas.ViewModels;

public partial class PesquisaDeAnagramasViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<string> listaDeAnagramas = [];

    string[] palavras = [];

    public async Task LerArquivoPalavrasTxt()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("palavras.txt");
        using var reader = new StreamReader(stream);

        var conteudo = reader.ReadToEnd();

        palavras = conteudo.Split('\n');
    }

    public void PesquisarAnagramas(string palavraDigitada)
    {
        ListaDeAnagramas.Clear();

        string auxiliar = palavraDigitada;

        foreach (string palavra in palavras)
        {      
            bool ehAnagrama = true;

            if (palavra.Length == 1 || palavra.Contains('-') || palavra.Contains('.') || palavra == palavraDigitada)
            {
                continue;
            }

            foreach (char letra in palavra)
            {
                if (palavraDigitada.Contains(letra))
                {
                    int indiceDaLetra = palavraDigitada.IndexOf(letra);
                    palavraDigitada = palavraDigitada.Substring(0, indiceDaLetra) + "*" + palavraDigitada.Substring(indiceDaLetra + 1);
                }
                else
                {
                    ehAnagrama = false;
                    break;
                }
            }

            if (ehAnagrama)
            {
                ListaDeAnagramas.Add(palavra);
            }
            palavraDigitada = auxiliar;
        }        
    }
}
