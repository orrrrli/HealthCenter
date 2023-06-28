using Domain.Model;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UserSheets
    {
        [Key]
        public int Id { get; set; }
        public User user { get; set; }
        public Sheet sheet { get; set; }
    }
}