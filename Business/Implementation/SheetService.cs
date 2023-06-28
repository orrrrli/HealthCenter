using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class SheetService : ISheetService
    {
        private readonly ISheetRepository _sheetRepository;

        public SheetService(ISheetRepository sheetRepository)
        {
            _sheetRepository = sheetRepository;
        }
        public int Add(Sheet sheet)
        {
            return _sheetRepository.Add(sheet);
        }

        public Sheet Get(int id)
        {
            Sheet sheet = _sheetRepository.Get(id);
            return sheet;
        }

        public bool Update(Sheet sheet)
        {
            if (sheet.Id <= 0) return false;
            return _sheetRepository.Update(sheet);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_sheetRepository.Delete(id));
        }

    }
}