using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MVVMappToolKitApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        [ObservableProperty]
        public string nome;

        [ObservableProperty]
        public string sobrenome;
        [ObservableProperty]
        private string pessoaGanhadora;
        [ObservableProperty]
        private string message;

        public ObservableCollection<string> Participantes { get; set; }
        public RelayCommand IncluirNomeCommand { get; private set; }
        public RelayCommand SortearNomeCommand { get; private set; }

        public MainViewModel()
        {
            IncluirNomeCommand = new RelayCommand(IncluirNome);
            SortearNomeCommand = new RelayCommand(SortearNome);
            Participantes = new ObservableCollection<string>();
        }

        private void SortearNome()
        {
            Message=string.Empty;
            try
            {
                if (!Participantes.Count.Equals(0))
                {
                    Random.Shared.Next(0, Participantes.Count);
                    var indice = Random.Shared.Next(0, Participantes.Count);
                    PessoaGanhadora = Participantes[indice];
                    App.Current.MainPage.DisplayAlert($"Parabéns {PessoaGanhadora} !!!", "Voce foi o ganhador desta  rodada. ;)", "Ok");
                    Participantes.Remove(PessoaGanhadora);
                    Message = string.Empty;

                }
                else
                {
                    Message = ("Impossivel realizar o sorteio. Erro: Lista vazia.");
                }
            }
            catch
            {
                Message=("Impossivel realizar o sorteio. Erro: Lista vazia.");
            }
        }

        private void IncluirNome()
        {
            Message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(Nome))
                {
                    Participantes.Add($"{Nome} {Sobrenome}");
                    Nome = string.Empty;
                    Sobrenome = string.Empty;
                    Message=string.Empty;

                }
                else
                {
                    Message=("Erro. O campo nome é obrigatorio.");
                }
            }
            catch
            {
                Message = ("Erro. Impossibile inserir dados.");
            }
        }
    }
}
