using Anagramas.ViewModels;

namespace Anagramas.Views;

public partial class PesquisaDeAnagramas : ContentPage
{
	PesquisaDeAnagramasViewModel pesquisaDeAnagramasViewModel = new();

	public PesquisaDeAnagramas()
	{
		InitializeComponent();
		BindingContext = pesquisaDeAnagramasViewModel;
        _ = pesquisaDeAnagramasViewModel.LerArquivoPalavrasTxt();
	}

    private void PesquisarButton_Clicked (object sender, EventArgs e)
	{
		pesquisaDeAnagramasViewModel.PesquisarAnagramas(Entrada.Text);
    }    
}