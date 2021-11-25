using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DiemDanhOTP.Models
{
    public partial class DIEMDANH_APIContext : DbContext
    {
        public DIEMDANH_APIContext()
        {
        }

        public DIEMDANH_APIContext(DbContextOptions<DIEMDANH_APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<GroupSubject> GroupSubjects { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionDetail> SessionDetails { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Study> Studies { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=DIEMDANH_API;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Idadmin);

                entity.Property(e => e.Idadmin)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDAdmin");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Usename)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Idcourse);

                entity.Property(e => e.Idcourse)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDCourse");

                entity.Property(e => e.CoursetName).HasMaxLength(100);

                entity.Property(e => e.Noc).HasColumnName("NOC");
            });

            modelBuilder.Entity<GroupSubject>(entity =>
            {
                entity.HasKey(e => e.Idgroup);

                entity.ToTable("GroupSubject");

                entity.HasIndex(e => e.Idcourse, "IX_Relationship10");

                entity.HasIndex(e => e.Idteacher, "IX_Relationship12");

                entity.Property(e => e.Idgroup).HasColumnName("IDGroup");

                entity.Property(e => e.Class)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.Idcourse)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDCourse");

                entity.Property(e => e.Idteacher).HasColumnName("IDTeacher");

                entity.HasOne(d => d.IdcourseNavigation)
                    .WithMany(p => p.GroupSubjects)
                    .HasForeignKey(d => d.Idcourse)
                    .HasConstraintName("Relationship10");

                entity.HasOne(d => d.IdteacherNavigation)
                    .WithMany(p => p.GroupSubjects)
                    .HasForeignKey(d => d.Idteacher)
                    .HasConstraintName("Relationship12");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.Idsession);

                entity.ToTable("Session");

                entity.HasIndex(e => e.Idgroup, "IX_Relationship28");

                entity.Property(e => e.Idsession).HasColumnName("IDSession");

                entity.Property(e => e.Classroom)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Day).HasMaxLength(20);

                entity.Property(e => e.Idgroup).HasColumnName("IDGroup");

                entity.Property(e => e.Session1).HasColumnName("Session");

                entity.HasOne(d => d.IdgroupNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.Idgroup)
                    .HasConstraintName("Relationship28");
            });

            modelBuilder.Entity<SessionDetail>(entity =>
            {
                entity.HasKey(e => new { e.Idlession, e.Idstuddent });

                entity.ToTable("SessionDetail");

                entity.Property(e => e.Idlession).HasColumnName("IDLession");

                entity.Property(e => e.Idstuddent)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDStuddent");

                entity.Property(e => e.Otp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("OTP");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.IdlessionNavigation)
                    .WithMany(p => p.SessionDetails)
                    .HasForeignKey(d => d.Idlession)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship1");

                entity.HasOne(d => d.IdstuddentNavigation)
                    .WithMany(p => p.SessionDetails)
                    .HasForeignKey(d => d.Idstuddent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship2");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Idstudent);

                entity.HasIndex(e => e.Id, "IX_Relationship27");

                entity.Property(e => e.Idstudent)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDStudent");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Class)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("Relationship27");
            });

            modelBuilder.Entity<Study>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Study");

                entity.Property(e => e.Idgroup).HasColumnName("IDGroup");

                entity.Property(e => e.Idstudent)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDStudent");

                entity.Property(e => e.Stt).HasColumnName("STT");

                entity.HasOne(d => d.IdgroupNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idgroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship13");

                entity.HasOne(d => d.IdstudentNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idstudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship14");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Idteacher);

                entity.HasIndex(e => e.Id, "IX_Relationship26");

                entity.Property(e => e.Idteacher).HasColumnName("IDTeacher");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SourceTeacher)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("Relationship26");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Idadmin, "IX_Relationship25");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idadmin).HasColumnName("IDAdmin");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Usename)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdadminNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Idadmin)
                    .HasConstraintName("Relationship25");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
