using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface ISheetRepository : IGenericRepository <Sheet>
    {
        bool RelateUser(int idUser, int idSheet); //Permite saber donde a que usuario le pertenece esta hoja

        List<User> GetUsers(int idSheet); // Permite linkear con la tabla intermedio
    }
}
