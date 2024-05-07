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
    internal class BanqueService : Service<Banque>, Ibanqueservice
    {
        private readonly IUnitOfWork _Uow;
        public BanqueService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {this._Uow = unitOfWork;
        }
    }
}
