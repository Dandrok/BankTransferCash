using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TransferTest.Models
{
    public class Conta
    {
        [Key]
        public int Conta_Id { get; set; }

        [Display(Name = "Conta")]
        public string NConta { get; set; }

        [DataType(DataType.Currency)]
        public float Saldo { get; set; }

        [Display(Name = "Cliente")]
        public int Cliente_Id { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}