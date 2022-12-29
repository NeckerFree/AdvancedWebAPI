using AWA.DataAccess;
using AWA.Domain.Interfaces;
using AWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWA.Repository
{
    public class BusinessEntityContactRepository : GenericRepository<BusinessEntityContact>, IBusinessEntityContactRepository
    {
        public BusinessEntityContactRepository(AdventureWorksContext context) : base(context)
        {
        }
    }
}
