using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public enum TypeCompte
    {
        Epargne,
        Courant
    }
    public class Compte
    {
        [Key]
        public string NumeroCompte { get; set; }
        public string Proprietaire { get; set; }
        public string Solde { get; set; }
        public TypeCompte Type { get; set; }
        public IList<Transaction> transactions { get; set; }
        public int BanqueFK { get; set; }
        [ForeignKey("BanqueFK")]
        public Banque banque { get; set; }

    }
}
