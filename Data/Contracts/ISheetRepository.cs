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
        List<MedicalRecord> GetMedicalRecord(int idSheet);

    }
}
