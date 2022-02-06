using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_com_Banco_de_Dados
{
    public class MainWindowsVM
    {
        public ObservableCollection<Usuario> listaUsuarios { get; set; }

        public ICommand Add { get; private set; }
        public ICommand Remove { get; private set; }
        public ICommand Update { get; private set; }

        public Usuario UsuarioSelecionado { get; set; }

        public MainWindowsVM()
        {
            listaUsuarios = new ObservableCollection<Usuario>();
            IniciaComandos();
        }

        public void IniciaComandos()
        {
            Add = new RelayCommand((object _) => {

                Usuario userCadastro = new Usuario();

                CadastroUsuario tela = new CadastroUsuario();
                tela.DataContext = userCadastro;
                tela.ShowDialog();

                //listaUsuarios.Add(userCadastro);
                if (tela.DialogResult.Value)
                {
                    listaUsuarios.Add(userCadastro);
                }

            });

            Remove = new RelayCommand((object _) => {
                listaUsuarios.Remove(UsuarioSelecionado);
            }, (object _) =>
            {
                return (UsuarioSelecionado != null);
                //return listaUsuarios.Count != 0;
            });

            Update = new RelayCommand((object _) => {

                Usuario usuarioNovo = UsuarioSelecionado.ShallowCopy(); ;
                CadastroUsuario tela = new CadastroUsuario();

                tela.DataContext = usuarioNovo;
                tela.ShowDialog();

                //listaUsuarios.Remove(usuarioAntigo);
                //listaUsuarios.Add(UsuarioSelecionado);

                listaUsuarios.Remove(UsuarioSelecionado);
                listaUsuarios.Add(usuarioNovo);

            }, (object _) =>
            {
                return (UsuarioSelecionado != null);
                //return listaUsuarios.Count != 0;
            });
        }
    }
}
