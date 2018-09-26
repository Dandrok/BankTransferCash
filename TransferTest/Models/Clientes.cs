using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransferTest.Models
{
    public class Clientes
    {
        [Key]
        public int Cliente_Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é requerido!")]
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Address { get; set; }

        public string Idade { get; set; }

        public string Sexo { get; set; }

        public virtual ICollection<Conta> Conta { get; set; }
    }
}