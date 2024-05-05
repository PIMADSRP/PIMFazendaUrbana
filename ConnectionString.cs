using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMFazendaUrbana
{
    internal class ConnectionString
    {
        public static string GetConnectionString()
        {
            return "Server=localhost;Database=testepim;Uid=root;Pwd=marcelogomesrp;"; // Substitua pelos valores reais da conexão com o banco de dados
        }
    }
}
