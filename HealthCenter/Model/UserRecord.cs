using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UserRecord
    {
        [Key]
        public int Id { get; set; }
        public MedicalRecord medicalRecord { get; set; }
        public User User { get; set; }
    }
}