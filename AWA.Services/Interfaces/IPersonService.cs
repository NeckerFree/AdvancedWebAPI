using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWA.Services.Interfaces
{
    public  interface IPersonService
    {
        Task<IEnumerable<DTOPeople>> GetAllPeople();
    }
    
}
