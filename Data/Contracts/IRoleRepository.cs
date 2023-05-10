using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IRoleRepository : IGenericRepository<Role> 

    {
        List<User> GetUsers(int idRole); // Metodo para relacionarlo con la tabla intermedia
    }
}
