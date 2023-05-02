using Business.Contracts;
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
        private readonly ISheetService _sheetService;

        public SheetService(ISheetService sheetService)
        {
            _sheetService = sheetService;
        }
        public int Add(Sheet sheet)
        {
            if (sheet.Id <= 0) return 0;
            if (string.IsNullOrEmpty(sheet.Nombre)) return 0;
            if (string.IsNullOrEmpty(sheet.Descripcion)) return 0;
            if (string.IsNullOrEmpty(sheet.Status)) return 0;
            return _sheetService.Add(sheet);
        }

        public Sheet Get(int id)
        {
            Sheet sheet = _sheetService.Get(id);
            return sheet;
        }

        public bool Update(Sheet sheet)
        {
            if (sheet.Id <= 0) return false;
            if (string.IsNullOrEmpty(sheet.Nombre)) return false;
            if (string.IsNullOrEmpty(sheet.Descripcion)) return false;
            if (string.IsNullOrEmpty(sheet.Status)) return false;
            return _sheetService.Update(sheet);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_sheetService.Delete(id));
        }

    }
}
