using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Model;

namespace Data
{
    public class HealthCenterDBContext : DbContext
    {
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<Role>Roles { get; set; }
        public DbSet<Sheet>Sheets { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet <UserRecord> UserRecords { get; set; }

        public DbSet <MedicalRecordSheet> medicalrecordSheets { get; set; }
        public HealthCenterDBContext() : base("HealthCenter")
        {

        }

    }
}
