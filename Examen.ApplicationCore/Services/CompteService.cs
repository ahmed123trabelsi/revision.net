using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class CompteService : Service<Compte>, Icompteservice
    {
        private readonly IUnitOfWork _Uow;
        public CompteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {this._Uow = unitOfWork;
        }

        public IEnumerable<Transaction> GettransactionBYcompteEargne(DateTime d)
        {
            var transactionsOnDate = GetAll().Where(a => a.Type ==TypeCompte.Epargne)  // Filter to get only savings accounts
        .SelectMany(a => a.transactions)         // Flatten the list of transactions from these accounts
        .Where(t => t.Date.Date == d.Date)    // Filter transactions to find those that occur on the specific date
        .ToList();
            return transactionsOnDate;
        }

        public int transactionbycompte(Compte c)
        {
            DayOfWeek currentDay = DateTime.Today.DayOfWeek;
            int daysToSubtract = (int)currentDay - (int)DayOfWeek.Monday;
            DateTime startOfWeek = DateTime.Today.AddDays(-daysToSubtract);

      
            return c.transactions.Where(t => t.Date >= startOfWeek && t.Date < DateTime.Now.AddDays(1)).Count();
        }
    }
}
