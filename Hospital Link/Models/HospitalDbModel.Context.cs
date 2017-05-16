﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital_Link.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HospitalDbEntities1 : DbContext
    {
        public HospitalDbEntities1()
            : base("name=HospitalDbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BloodBank> BloodBanks { get; set; }
        public virtual DbSet<ChandedRecord> ChandedRecords { get; set; }
        public virtual DbSet<Chemist> Chemists { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<HospitalRole> HospitalRoles { get; set; }
        public virtual DbSet<HospitalUser> HospitalUsers { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Medical_Stuff> Medical_Stuff { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<RecordAtlerLog> RecordAtlerLogs { get; set; }
        public virtual DbSet<Regestration_date> Regestration_dates { get; set; }
        public virtual DbSet<ChemistView> ChemistViews { get; set; }
        public virtual DbSet<Doctores_More_Details> Doctores_More_Details { get; set; }
        public virtual DbSet<DoctorsView> DoctorsViews { get; set; }
        public virtual DbSet<HOSPITAL_INFO> HOSPITAL_INFOes { get; set; }
        public virtual DbSet<Nursesview> Nursesviews { get; set; }
        public virtual DbSet<View> Views { get; set; }
    
        public virtual ObjectResult<Search_Result> Search(Nullable<int> param1)
        {
            var param1Parameter = param1.HasValue ?
                new ObjectParameter("param1", param1) :
                new ObjectParameter("param1", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Search_Result>("Search", param1Parameter);
        }
    }
}
