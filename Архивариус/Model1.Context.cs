﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Архивариус
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gr682_gnmEntities : DbContext
    {
        public gr682_gnmEntities()
            : base("name=gr682_gnmEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Archive_work> Archive_work { get; set; }
        public virtual DbSet<Authorized_user_role> Authorized_user_role { get; set; }
        public virtual DbSet<Issuance> Issuance { get; set; }
        public virtual DbSet<Reg> Reg { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Storage_article> Storage_article { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
