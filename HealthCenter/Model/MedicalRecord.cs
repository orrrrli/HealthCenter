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
        public double Size { get; set; }
        public double sBP { get; set; } //systolic blood pressure

        public double dBP { get; set; } // diastolic blood pressure
        public DateTime CreatedDate { get; set; }
        public List<UserRecord> UsersRecords { get; set; }
    }
}
