using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MedicalRecordSheet> MedicalRecordSheets { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<UserRecord> UsersRecords { get; set; }
    }
}
