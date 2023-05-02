using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface ISheetService
    {
        int Add(Sheet sheet);
        Sheet Get(int id);
        bool Update(Sheet sheet);
        bool Delete(int id);


    }
}
