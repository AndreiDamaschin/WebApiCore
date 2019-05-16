using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.Models
{
    public partial class UsersIEP_dev01Context : DbContext
    {
        public UsersIEP_dev01Context()
        {
        }

        public UsersIEP_dev01Context(DbContextOptions<UsersIEP_dev01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<_1ccontractWorkers> _1ccontractWorkers { get; set; }
        public virtual DbSet<_1cdepartament> _1cdepartament { get; set; }
        public virtual DbSet<_1cfunction> _1cfunction { get; set; }
        public virtual DbSet<_1cindividuals> _1cindividuals { get; set; }
        public virtual DbSet<_1clogSync> _1clogSync { get; set; }
        public virtual DbSet<ElkActions> ElkActions { get; set; }
        public virtual DbSet<ElkPermission> ElkPermission { get; set; }
        public virtual DbSet<ElkResource> ElkResource { get; set; }
        public virtual DbSet<ElkRole> ElkRole { get; set; }
        public virtual DbSet<ElkRoleCompany> ElkRoleCompany { get; set; }
        public virtual DbSet<ElkRoleDepartment> ElkRoleDepartment { get; set; }
        public virtual DbSet<ElkRoleEmployment> ElkRoleEmployment { get; set; }
        public virtual DbSet<ElkRolePermission> ElkRolePermission { get; set; }
        public virtual DbSet<ElkRoleSubdepart> ElkRoleSubdepart { get; set; }
        public virtual DbSet<ElkRoleUsers> ElkRoleUsers { get; set; }
        public virtual DbSet<ElkSessionLogs> ElkSessionLogs { get; set; }
        public virtual DbSet<EventCheckWorkersInRanepa> EventCheckWorkersInRanepa { get; set; }
        public virtual DbSet<GreetingsPhrases> GreetingsPhrases { get; set; }
        public virtual DbSet<LogChange> LogChange { get; set; }
        public virtual DbSet<LogErrors> LogErrors { get; set; }
        public virtual DbSet<SprCompany> SprCompany { get; set; }
        public virtual DbSet<SprDepartment> SprDepartment { get; set; }
        public virtual DbSet<SprEmployment> SprEmployment { get; set; }
        public virtual DbSet<SprFunction> SprFunction { get; set; }
        public virtual DbSet<SprHuman> SprHuman { get; set; }
        public virtual DbSet<SprSex> SprSex { get; set; }
        public virtual DbSet<SprSubDepartment> SprSubDepartment { get; set; }
        public virtual DbSet<SprTitle> SprTitle { get; set; }
        public virtual DbSet<SprWorkPhoneIep> SprWorkPhoneIep { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SRV-SQL1.iet.int;Initial Catalog=UsersIEP_dev01;User ID=sql-elk;Password=CK_V5EGw");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<_1ccontractWorkers>(entity =>
            {
                entity.HasKey(e => new { e.IdIndivid, e.IdWorker });

                entity.ToTable("1CContractWorkers");

                entity.Property(e => e.IdIndivid)
                    .HasColumnName("ID_Individ")
                    .HasMaxLength(36);

                entity.Property(e => e.IdWorker)
                    .HasColumnName("ID_Worker")
                    .HasMaxLength(36);

                entity.Property(e => e.DateCreate)
                    .HasColumnName("DATE_CREATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEdit)
                    .HasColumnName("DATE_EDIT")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FlgUpdate).HasColumnName("FLG_UPDATE");

                entity.Property(e => e.Greeting).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.NumerDoc)
                    .HasColumnName("NUMER_DOC")
                    .HasMaxLength(6);

                entity.Property(e => e.SecName).HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Tn)
                    .HasColumnName("TN")
                    .HasMaxLength(10);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("UPDATE_BY")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<_1cdepartament>(entity =>
            {
                entity.HasKey(e => e.IdDepart);

                entity.ToTable("1CDepartament");

                entity.Property(e => e.IdDepart)
                    .HasColumnName("ID_DEPART")
                    .HasMaxLength(36)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateBegin)
                    .HasColumnName("DATE_BEGIN")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("DATE_CREATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEdit)
                    .HasColumnName("DATE_EDIT")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("DATE_END")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(150);

                entity.Property(e => e.FlgUpdate).HasColumnName("FLG_UPDATE");

                entity.Property(e => e.IdHead)
                    .HasColumnName("ID_HEAD")
                    .HasMaxLength(36);

                entity.Property(e => e.IdOwner)
                    .HasColumnName("ID_OWNER")
                    .HasMaxLength(36);

                entity.Property(e => e.IdParent)
                    .HasColumnName("ID_PARENT")
                    .HasMaxLength(36);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("UPDATE_BY")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<_1cfunction>(entity =>
            {
                entity.HasKey(e => e.IdFunc);

                entity.ToTable("1CFunction");

                entity.Property(e => e.IdFunc)
                    .HasColumnName("ID_FUNC")
                    .HasMaxLength(36)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateBegin)
                    .HasColumnName("DATE_BEGIN")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("DATE_CREATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEdit)
                    .HasColumnName("DATE_EDIT")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("DATE_END")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(150);

                entity.Property(e => e.FlgUpdate).HasColumnName("FLG_UPDATE");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("UPDATE_BY")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<_1cindividuals>(entity =>
            {
                entity.HasKey(e => new { e.IdIndivid, e.IdWorker });

                entity.ToTable("1CIndividuals");

                entity.Property(e => e.IdIndivid)
                    .HasColumnName("ID_Individ")
                    .HasMaxLength(36);

                entity.Property(e => e.IdWorker)
                    .HasColumnName("ID_Worker")
                    .HasMaxLength(36);

                entity.Property(e => e.DateBeginWork)
                    .HasColumnName("DATE_BEGIN_WORK")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("DATE_CREATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEdit)
                    .HasColumnName("DATE_EDIT")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEndWork)
                    .HasColumnName("DATE_END_WORK")
                    .HasColumnType("datetime");

                entity.Property(e => e.Employment)
                    .HasColumnName("employment")
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FlgUpdate).HasColumnName("FLG_UPDATE");

                entity.Property(e => e.Greeting).HasColumnType("datetime");

                entity.Property(e => e.IdDepart)
                    .IsRequired()
                    .HasColumnName("ID_DEPART")
                    .HasMaxLength(36);

                entity.Property(e => e.IdFunction)
                    .IsRequired()
                    .HasColumnName("ID_FUNCTION")
                    .HasMaxLength(36);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.NumerDoc)
                    .HasColumnName("NUMER_DOC")
                    .HasMaxLength(6);

                entity.Property(e => e.SecName).HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Tn)
                    .HasColumnName("TN")
                    .HasMaxLength(10);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("UPDATE_BY")
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdDepartNavigation)
                    .WithMany(p => p._1cindividuals)
                    .HasForeignKey(d => d.IdDepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_1CIndividuals_1CDepartament");

                entity.HasOne(d => d.IdFunctionNavigation)
                    .WithMany(p => p._1cindividuals)
                    .HasForeignKey(d => d.IdFunction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_1CIndividuals_1CFunction");
            });

            modelBuilder.Entity<_1clogSync>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.ToTable("1CLogSync");

                entity.Property(e => e.DateSync).HasColumnType("datetime");

                entity.Property(e => e.GuidObject1C)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.IdObjectImb).HasColumnName("IdObjectIMB");

                entity.Property(e => e.InfoAction).HasColumnName("infoAction");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ElkActions>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.Property(e => e.ActionTitle).HasMaxLength(50);

                entity.Property(e => e.UodetedBy).HasMaxLength(255);
            });

            modelBuilder.Entity<ElkPermission>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.Property(e => e.PermissionName).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(255);

                entity.HasOne(d => d.ActionKeyNavigation)
                    .WithMany(p => p.ElkPermission)
                    .HasForeignKey(d => d.ActionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ElkPermission_ElkActions");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.ElkPermission)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ElkPermission_ElkResource");
            });

            modelBuilder.Entity<ElkResource>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.Property(e => e.RefKey).ValueGeneratedNever();

                entity.Property(e => e.ResourceName).HasMaxLength(150);

                entity.Property(e => e.UpdateBy).HasMaxLength(255);
            });

            modelBuilder.Entity<ElkRole>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<ElkRoleCompany>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ElkRoleCompany)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_ElkRoleCompany_SprCompany");

                entity.HasOne(d => d.RoleKeyNavigation)
                    .WithMany(p => p.ElkRoleCompany)
                    .HasForeignKey(d => d.RoleKey)
                    .HasConstraintName("FK_ElkRoleCompany_ElkRole");
            });

            modelBuilder.Entity<ElkRoleDepartment>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ElkRoleDepartment)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ElkRoleDepartment_SprDepartment");

                entity.HasOne(d => d.RoleKeyNavigation)
                    .WithMany(p => p.ElkRoleDepartment)
                    .HasForeignKey(d => d.RoleKey)
                    .HasConstraintName("FK_ElkRoleDepartment_ElkRole");
            });

            modelBuilder.Entity<ElkRoleEmployment>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.Property(e => e.EmploymentId).HasColumnName("EmploymentID");

                entity.Property(e => e.RoleKey).HasColumnName("RoleKEy");

                entity.HasOne(d => d.Employment)
                    .WithMany(p => p.ElkRoleEmployment)
                    .HasForeignKey(d => d.EmploymentId)
                    .HasConstraintName("FK_ElkRoleEmployment_SprEmployment");

                entity.HasOne(d => d.RoleKeyNavigation)
                    .WithMany(p => p.ElkRoleEmployment)
                    .HasForeignKey(d => d.RoleKey)
                    .HasConstraintName("FK_ElkRoleEmployment_ElkRole");
            });

            modelBuilder.Entity<ElkRolePermission>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.HasOne(d => d.PermissionKeyNavigation)
                    .WithMany(p => p.ElkRolePermission)
                    .HasForeignKey(d => d.PermissionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ElkRolePermission_ElkPermission");

                entity.HasOne(d => d.RoleKeyNavigation)
                    .WithMany(p => p.ElkRolePermission)
                    .HasForeignKey(d => d.RoleKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ElkRolePermission_ElkRole");
            });

            modelBuilder.Entity<ElkRoleSubdepart>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.Property(e => e.SubDepartmentId).HasColumnName("SubDepartmentID");

                entity.HasOne(d => d.RoleKeyNavigation)
                    .WithMany(p => p.ElkRoleSubdepart)
                    .HasForeignKey(d => d.RoleKey)
                    .HasConstraintName("FK_ElkRoleSubdepart_ElkRole");

                entity.HasOne(d => d.SubDepartment)
                    .WithMany(p => p.ElkRoleSubdepart)
                    .HasForeignKey(d => d.SubDepartmentId)
                    .HasConstraintName("FK_ElkRoleSubdepart_SprSubDepartment");
            });

            modelBuilder.Entity<ElkRoleUsers>(entity =>
            {
                entity.HasKey(e => e.RefKey);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.RoleKeyNavigation)
                    .WithMany(p => p.ElkRoleUsers)
                    .HasForeignKey(d => d.RoleKey)
                    .HasConstraintName("FK_ElkRoleUsers_ElkRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ElkRoleUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ElkRoleUsers_SprHuman");
            });

            modelBuilder.Entity<ElkSessionLogs>(entity =>
            {
                entity.HasKey(e => e.SessionId);

                entity.Property(e => e.SessionId)
                    .HasColumnName("SessionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccauntUsers).HasMaxLength(50);

                entity.Property(e => e.DateEvent).HasColumnType("datetime");

                entity.Property(e => e.Hash).HasColumnName("hash");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ipAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.UsersAgent).HasColumnName("usersAgent");
            });

            modelBuilder.Entity<EventCheckWorkersInRanepa>(entity =>
            {
                entity.HasIndex(e => e.IdHuman)
                    .HasName("EventCheckWorkersInRanepa$EventCheckWorkersInRanepa$SprHumanEventCheckWorkersInRanepa");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataDismisial).HasColumnType("datetime");

                entity.Property(e => e.DataProcess).HasColumnType("datetime");

                entity.Property(e => e.FlgCloss).HasColumnName("flgCloss");

                entity.Property(e => e.FlgDel).HasColumnName("flgDel");

                entity.Property(e => e.FlgDiss).HasColumnName("flgDiss");

                entity.Property(e => e.FlgWorkFrend).HasColumnName("flgWorkFrend");

                entity.Property(e => e.FlgWorkVavt).HasColumnName("flgWorkVAVT");

                entity.Property(e => e.IdInd)
                    .HasColumnName("ID_IND")
                    .HasMaxLength(36);
            });

            modelBuilder.Entity<GreetingsPhrases>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime2(0)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<LogChange>(entity =>
            {
                entity.HasKey(e => e.IdChange);

                entity.HasIndex(e => e.IdHuman)
                    .HasName("LogChange$LogChange$SprHumanLogChange");

                entity.Property(e => e.IdChange).HasColumnName("idChange");

                entity.Property(e => e.IdHuman).HasColumnName("idHuman");

                entity.Property(e => e.NDate)
                    .HasColumnName("nDate")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.NewData).HasMaxLength(255);

                entity.Property(e => e.OldData).HasMaxLength(255);

                entity.Property(e => e.ProcName).HasMaxLength(255);

                entity.Property(e => e.Result).HasMaxLength(255);

                entity.Property(e => e.UpdateBy).HasMaxLength(255);
            });

            modelBuilder.Entity<LogErrors>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ErrUser)
                    .HasColumnName("err_user")
                    .HasMaxLength(50);

                entity.Property(e => e.ErrorCode).HasColumnName("error_code");

                entity.Property(e => e.ErrorDate)
                    .HasColumnName("error_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.ErrorLevel).HasColumnName("error_level");

                entity.Property(e => e.ErrorSource)
                    .HasColumnName("error_source")
                    .HasMaxLength(100);

                entity.Property(e => e.ErrorText)
                    .HasColumnName("error_text")
                    .HasMaxLength(250);

                entity.Property(e => e.ErrorType).HasColumnName("error_type");

                entity.Property(e => e.ExtendText)
                    .HasColumnName("extend_text")
                    .HasMaxLength(140);
            });

            modelBuilder.Entity<SprCompany>(entity =>
            {
                entity.HasKey(e => e.IdPlace);

                entity.Property(e => e.AddressEng).HasMaxLength(100);

                entity.Property(e => e.AddressRus).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime2(0)");

                entity.Property(e => e.FullNamePlace).HasMaxLength(50);

                entity.Property(e => e.FullNmaePlaceEng).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.ShortNamePlace).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime2(0)");

                entity.Property(e => e.ZipCode).HasMaxLength(255);
            });

            modelBuilder.Entity<SprDepartment>(entity =>
            {
                entity.HasKey(e => e.IdDepart);

                entity.HasIndex(e => e.IdPlace)
                    .HasName("SprDepartment$SprDepartment$SprDepartmentIdPlace");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime2(0)");

                entity.Property(e => e.FlgDisable).HasColumnName("flgDisable");

                entity.Property(e => e.Id1Cspr)
                    .HasColumnName("Id1CSpr")
                    .HasMaxLength(255);

                entity.Property(e => e.NameDepart).HasMaxLength(255);

                entity.Property(e => e.NameDepartEng).HasMaxLength(255);

                entity.Property(e => e.ParentKey1C).HasMaxLength(36);

                entity.Property(e => e.RefKey1C).HasMaxLength(36);

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime2(0)");

                entity.HasOne(d => d.IdPlaceNavigation)
                    .WithMany(p => p.SprDepartment)
                    .HasForeignKey(d => d.IdPlace)
                    .HasConstraintName("FK_SprDepartment_SprCompany");
            });

            modelBuilder.Entity<SprEmployment>(entity =>
            {
                entity.HasKey(e => e.IdEmployment);

                entity.Property(e => e.IdEmployment).HasColumnName("idEmployment");

                entity.Property(e => e.Employment).HasMaxLength(255);

                entity.Property(e => e.OunameForUsers)
                    .HasColumnName("OUNameForUsers")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SprFunction>(entity =>
            {
                entity.HasKey(e => e.IdFunction);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime2(0)");

                entity.Property(e => e.FlgDisable).HasColumnName("flgDisable");

                entity.Property(e => e.NameFunction).HasMaxLength(128);

                entity.Property(e => e.NameFunctionEng).HasMaxLength(128);

                entity.Property(e => e.RefKey1C).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<SprHuman>(entity =>
            {
                entity.HasKey(e => e.IdHuman);

                entity.HasIndex(e => e.IdEmployment)
                    .HasName("SprHuman$SprHuman$SprEmploymentSprHuman");

                entity.HasIndex(e => e.IdFunction)
                    .HasName("SprHuman$SprHuman$SprFunctionSprHuman");

                entity.HasIndex(e => e.IdSex)
                    .HasName("SprHuman$SprHuman$SprSexSprHuman");

                entity.HasIndex(e => e.IdSubDepart)
                    .HasName("SprHuman$SprHuman$SprSubDepartmentSprHuman");

                entity.HasIndex(e => e.IdTitle)
                    .HasName("SprHuman$SprHuman$SprTitleSprHuman");

                entity.HasIndex(e => e.IdWorkPhoneIep)
                    .HasName("SprHuman$SprHuman$SprWorkPhoneIEPSprHuman");

                entity.HasIndex(e => e.SamaccountName)
                    .HasName("SprHuman$SprHuman$SAMAccountName")
                    .IsUnique();

                entity.Property(e => e.Birthday).HasColumnType("datetime2(0)");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime2(0)");

                entity.Property(e => e.DateOfDismissal).HasColumnType("datetime2(0)");

                entity.Property(e => e.DateOfReceipt).HasColumnType("datetime2(0)");

                entity.Property(e => e.DisplayNamePrintable)
                    .HasColumnName("displayNamePrintable")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.FlgCallendar).HasColumnName("flgCallendar");

                entity.Property(e => e.FlgCheckDiss).HasColumnName("flgCheckDiss");

                entity.Property(e => e.FlgGreeting).HasColumnName("flgGreeting");

                entity.Property(e => e.FlgShare).HasColumnName("flgShare");

                entity.Property(e => e.GuidfromParsec3).HasColumnName("GUIDfromParsec3");

                entity.Property(e => e.HomePhone).HasMaxLength(255);

                entity.Property(e => e.IdActionPrn).HasColumnName("idActionPRN");

                entity.Property(e => e.IdEmployment).HasColumnName("idEmployment");

                entity.Property(e => e.IdQuotaPrn).HasColumnName("idQuotaPRN");

                entity.Property(e => e.IdUserPrn).HasColumnName("idUserPRN");

                entity.Property(e => e.IdWorkPhoneIep).HasColumnName("IdWorkPhoneIEP");

                entity.Property(e => e.KeyIndividIep)
                    .HasColumnName("KeyIndividIEP")
                    .HasMaxLength(36);

                entity.Property(e => e.KeyWorkerIep)
                    .HasColumnName("KeyWorkerIEP")
                    .HasMaxLength(36);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.MailAddress).HasMaxLength(255);

                entity.Property(e => e.MailForResetPass).HasMaxLength(50);

                entity.Property(e => e.MobilePhone).HasMaxLength(15);

                entity.Property(e => e.NumDocument).HasMaxLength(6);

                entity.Property(e => e.Office).HasMaxLength(10);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.SamaccountName)
                    .IsRequired()
                    .HasColumnName("SAMAccountName")
                    .HasMaxLength(15);

                entity.Property(e => e.SecName).HasMaxLength(255);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.Property(e => e.Tn).HasColumnName("TN");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime2(0)");

                entity.HasOne(d => d.IdEmploymentNavigation)
                    .WithMany(p => p.SprHuman)
                    .HasForeignKey(d => d.IdEmployment)
                    .HasConstraintName("FK_SprHuman_SprEmployment");

                entity.HasOne(d => d.IdFunctionNavigation)
                    .WithMany(p => p.SprHuman)
                    .HasForeignKey(d => d.IdFunction)
                    .HasConstraintName("FK_SprHuman_SprFunction");

                entity.HasOne(d => d.IdSexNavigation)
                    .WithMany(p => p.SprHuman)
                    .HasForeignKey(d => d.IdSex)
                    .HasConstraintName("FK_SprHuman_SprSex");

                entity.HasOne(d => d.IdSubDepartNavigation)
                    .WithMany(p => p.SprHuman)
                    .HasForeignKey(d => d.IdSubDepart)
                    .HasConstraintName("FK_SprHuman_SprSubDepartment");

                entity.HasOne(d => d.IdTitleNavigation)
                    .WithMany(p => p.SprHuman)
                    .HasForeignKey(d => d.IdTitle)
                    .HasConstraintName("FK_SprHuman_SprTitle");

                entity.HasOne(d => d.IdWorkPhoneIepNavigation)
                    .WithMany(p => p.SprHuman)
                    .HasForeignKey(d => d.IdWorkPhoneIep)
                    .HasConstraintName("FK_SprHuman_SprWorkPhoneIEP");
            });

            modelBuilder.Entity<SprSex>(entity =>
            {
                entity.HasKey(e => e.IdSex);

                entity.Property(e => e.SexEngSh).HasMaxLength(1);

                entity.Property(e => e.SexRus).HasMaxLength(255);
            });

            modelBuilder.Entity<SprSubDepartment>(entity =>
            {
                entity.HasKey(e => e.IdSubDepart);

                entity.HasIndex(e => e.IdDepart)
                    .HasName("SprSubDepartment$SprSubDepartment$SprDepartmentSprSubDepartment");

                entity.Property(e => e.AlphabetDepartAd)
                    .HasColumnName("AlphabetDepartAD")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime2(0)");

                entity.Property(e => e.FlgDisable).HasColumnName("flgDisable");

                entity.Property(e => e.GroupResRw)
                    .HasColumnName("GroupResRW")
                    .HasMaxLength(255);

                entity.Property(e => e.GroupSec).HasMaxLength(255);

                entity.Property(e => e.GtoupResRo)
                    .HasColumnName("GtoupResRO")
                    .HasMaxLength(255);

                entity.Property(e => e.Head).HasMaxLength(36);

                entity.Property(e => e.Id1Cspr)
                    .HasColumnName("Id1CSpr")
                    .HasMaxLength(255);

                entity.Property(e => e.NameDirDepartFs)
                    .HasColumnName("NameDirDepartFS")
                    .HasMaxLength(255);

                entity.Property(e => e.NameSubDepart).HasMaxLength(255);

                entity.Property(e => e.NameSubDepartEng).HasMaxLength(255);

                entity.Property(e => e.ParentKey1C).HasMaxLength(36);

                entity.Property(e => e.RefKey1C).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime2(0)");

                entity.HasOne(d => d.IdDepartNavigation)
                    .WithMany(p => p.SprSubDepartment)
                    .HasForeignKey(d => d.IdDepart)
                    .HasConstraintName("FK_SprSubDepartment_SprDepartment");
            });

            modelBuilder.Entity<SprTitle>(entity =>
            {
                entity.HasKey(e => e.IdTitle);

                entity.Property(e => e.IdTitle).HasColumnName("ID_Title");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime2(0)");

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.ShortNameTitle).HasMaxLength(255);

                entity.Property(e => e.ShortNameTitleEng).HasMaxLength(255);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<SprWorkPhoneIep>(entity =>
            {
                entity.HasKey(e => e.IdWorkPhone);

                entity.ToTable("SprWorkPhoneIEP");

                entity.Property(e => e.NumerPhone).HasMaxLength(255);
            });
        }
    }
}
