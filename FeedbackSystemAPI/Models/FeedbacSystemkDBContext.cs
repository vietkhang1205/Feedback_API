using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FeedbackSystemAPI.Models
{
    public partial class FeedbacSystemkDBContext : DbContext
    {
        public FeedbacSystemkDBContext()
        {
        }

        public FeedbacSystemkDBContext(DbContextOptions<FeedbacSystemkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignTask> AssignTasks { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FeedbacSystemkDB;Persist Security Info=True;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AssignTask>(entity =>
            {
                entity.HasKey(e => e.AssignId);

                entity.ToTable("AssignTask");

                entity.Property(e => e.AssignId)
                    .HasMaxLength(50)
                    .HasColumnName("AssignID");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.TaskId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TaskID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssignTasks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssignTask_User");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.AssignTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssignTask_Task");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(50)
                    .HasColumnName("DeviceID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .HasColumnName("LocationID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Device_Location1");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId)
                    .HasMaxLength(50)
                    .HasColumnName("FeedbackID");

                entity.Property(e => e.CustomerName).HasMaxLength(50);

                entity.Property(e => e.DateTime).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(50)
                    .HasColumnName("DeviceID");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK_Feedback_Device");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Feedback_User");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .HasColumnName("LocationID");

                entity.Property(e => e.Floor).HasMaxLength(50);

                entity.Property(e => e.LocatitonName).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.TaskId)
                    .HasMaxLength(50)
                    .HasColumnName("TaskID");

                entity.Property(e => e.DateTime).HasMaxLength(50);

                entity.Property(e => e.FeedbackId)
                    .HasMaxLength(50)
                    .HasColumnName("FeedbackID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.FeedbackId)
                    .HasConstraintName("FK_Task_Feedback");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
