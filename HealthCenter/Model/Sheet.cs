using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Sheet
    {
        [Key]
        public int Id { get; set; }
        public bool mellitusDiabetes { get; set; }
        public bool arterialHypertension { get; set; }
        public bool hypercholesterolemia { get; set; }
        public bool hypertriglyceridemia { get; set; }
        public bool chronicRenalFailure { get; set; }
        public bool heartDisease { get; set; }

        public bool liverDiseases { get; set; }
    }
}
