using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_com_Banco_de_Dados
{
    public class Usuario
    {
        private string name;
        private string email;
        private string password;
        public Usuario()
        {

        }

        public Usuario(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Usuario ShallowCopy()
        {
            return (Usuario)this.MemberwiseClone();
        }
    }
}
