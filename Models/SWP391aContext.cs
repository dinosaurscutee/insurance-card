using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InsuranceCard1.Models
{
    public partial class SWP391aContext : DbContext
    {
        public SWP391aContext()
        {
        }

        public SWP391aContext(DbContextOptions<SWP391aContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accidenthistory> Accidenthistories { get; set; }
        public virtual DbSet<Compensationhistory> Compensationhistories { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<CustomerUser> CustomerUsers { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Paymenthistory> Paymenthistories { get; set; }
        public virtual DbSet<Punishmenthistory> Punishmenthistories { get; set; }
        public virtual DbSet<StaffUser> StaffUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =DESKTOP-786FVHE; database = SWP391a;uid=sa;pwd=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Accidenthistory>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__ACCIDENT__B9BE370F9EB4B61C");

                entity.ToTable("ACCIDENTHISTORY");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.AccidentInfo)
                    .HasMaxLength(50)
                    .HasColumnName("accident_info");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("amount");

                entity.Property(e => e.Checked).HasColumnName("checked");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.HistoryId).HasColumnName("historyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Seen).HasColumnName("seen");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_phone");

                entity.HasOne(d => d.History)
                    .WithMany(p => p.Accidenthistories)
                    .HasForeignKey(d => d.HistoryId)
                    .HasConstraintName("FK__ACCIDENTH__histo__38996AB5");
            });

            modelBuilder.Entity<Compensationhistory>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__COMPENSA__B9BE370F3CDCF953");

                entity.ToTable("COMPENSATIONHISTORY");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("amount");

                entity.Property(e => e.Checked).HasColumnName("checked");

                entity.Property(e => e.CompensationInfo)
                    .HasMaxLength(50)
                    .HasColumnName("compensation_info");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.HistoryId).HasColumnName("historyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Seen).HasColumnName("seen");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_phone");

                entity.HasOne(d => d.History)
                    .WithMany(p => p.Compensationhistories)
                    .HasForeignKey(d => d.HistoryId)
                    .HasConstraintName("FK__COMPENSAT__histo__32E0915F");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("CONTRACT");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("amount");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PaymentInfo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("payment_info");

                entity.Property(e => e.StaffId).HasColumnName("staffID");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_phone");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CONTRACT__custom__3C69FB99");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__CONTRACT__staffI__3B75D760");
            });

            modelBuilder.Entity<CustomerUser>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__CUSTOMER__B611CB9D09722595");

                entity.ToTable("CUSTOMER_USER");

                entity.HasIndex(e => e.Username, "UQ__CUSTOMER__F3DBC572C60A8B58")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customerID");

                entity.Property(e => e.Address)
                    .HasMaxLength(128)
                    .HasColumnName("address");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .HasColumnName("gender");

                entity.Property(e => e.IdentityNumber).HasColumnName("identity_number");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.StaffId).HasColumnName("staffID");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.CustomerUsers)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__CUSTOMER___staff__2A4B4B5E");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("HISTORY");

                entity.Property(e => e.HistoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("historyID");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("name");

                entity.Property(e => e.TypeHistory)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("type_history");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__HISTORY__custome__2D27B809");
            });

            modelBuilder.Entity<Paymenthistory>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__PAYMENTH__ED1FC9EABC61E6CD");

                entity.ToTable("PAYMENTHISTORY");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.HistoryId).HasColumnName("historyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PaymentInfo)
                    .HasMaxLength(50)
                    .HasColumnName("payment_info");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_phone");

                entity.HasOne(d => d.History)
                    .WithMany(p => p.Paymenthistories)
                    .HasForeignKey(d => d.HistoryId)
                    .HasConstraintName("FK__PAYMENTHI__histo__300424B4");
            });

            modelBuilder.Entity<Punishmenthistory>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__PUNISHME__B9BE370F3431827C");

                entity.ToTable("PUNISHMENTHISTORY");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("amount");

                entity.Property(e => e.Checked).HasColumnName("checked");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.HistoryId).HasColumnName("historyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PunishmentInfo)
                    .HasMaxLength(50)
                    .HasColumnName("punishment_info");

                entity.Property(e => e.Seen).HasColumnName("seen");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_phone");

                entity.HasOne(d => d.History)
                    .WithMany(p => p.Punishmenthistories)
                    .HasForeignKey(d => d.HistoryId)
                    .HasConstraintName("FK__PUNISHMEN__histo__35BCFE0A");
            });

            modelBuilder.Entity<StaffUser>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__STAFF_US__6465E19E22C5A977");

                entity.ToTable("STAFF_USER");

                entity.HasIndex(e => e.Username, "UQ__STAFF_US__F3DBC5721F28BC71")
                    .IsUnique();

                entity.Property(e => e.StaffId)
                    .ValueGeneratedNever()
                    .HasColumnName("staffID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
