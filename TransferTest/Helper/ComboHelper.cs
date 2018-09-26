using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using TransferTest.Models;

namespace TransferTest.Helper
{
    public class ComboHelper : IDisposable
    {
        private static Context db = new Context();




        //ORDENAÇÕES
        public static List<Conta> GetConta()
        {


            var dep = db.Contas.ToList();
            dep.Add(new Conta
            {
                Cliente_Id = 0,
                NConta = "[ Selecione um Departamento ]"
            });

            return dep = dep.OrderBy(d => d.NConta).ToList();

        }

        public static List<Clientes> GetClientes()
        {


            var dep = db.Clientes.ToList();
            dep.Add(new Clientes
            {
                Cliente_Id = 0,
                Nome = "[ Selecione um Nome ]"
            });

            return dep = dep.OrderBy(d => d.Nome).ToList();

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}