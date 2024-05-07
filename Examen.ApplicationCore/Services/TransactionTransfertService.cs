using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class TransactionTransfertService : Service<TransactionTransfert>, Itransactiontransfer
    {
        private readonly IUnitOfWork _Uow;
        public TransactionTransfertService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {this._Uow = unitOfWork;
        }

        public int GetSommeMontant(DAB dab)
        {
          return  GetMany(t => t.dAB.DABid == dab.DABid).Sum(t => t.Montant);
        }
    }
}
