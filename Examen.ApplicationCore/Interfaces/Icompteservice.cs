using AM.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface Icompteservice : IService<Compte>
    {
        int transactionbycompte(Compte c);
        IEnumerable<Transaction> GettransactionBYcompteEargne(DateTime d);
    }
}
