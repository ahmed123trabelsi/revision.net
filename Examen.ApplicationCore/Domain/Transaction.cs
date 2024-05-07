using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public int Montant { get; set; }
       
        public string DABFk { get; set; }
        [ForeignKey("DABFk")]
        public DAB dAB { get; set; }
        public string CompteFk { get; set; }
        [ForeignKey("CompteFk")]
        public Compte compte { get; set; }

      
    }
}
