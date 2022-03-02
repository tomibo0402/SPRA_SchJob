using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class SPRA_SCHContext : DbContext
    {
        public SPRA_SCHContext()
        {
        }

        public SPRA_SCHContext(DbContextOptions<SPRA_SCHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmailRecord> EmailRecords { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<SystemParameter> SystemParameters { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<SystemRole> SystemRoles { get; set; }
        public virtual DbSet<SystemRoleFunction> SystemRoleFunctions { get; set; }
        public virtual DbSet<SystemUserRole> SystemUserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=172.16.0.153;Initial Catalog=SRPA_MIS;User ID=MIS;Password=P@ss1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            
            modelBuilder.Entity<EmailRecord>(entity =>
            {
                entity.ToTable("email_record");

                entity.Property(e => e.EmailRecordId).HasColumnName("email_record_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsSent)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_sent")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.ReceivedPost)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("received_post");

                entity.Property(e => e.ReceivedUnit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("received_unit");

                entity.Property(e => e.ReceivedUser).HasColumnName("received_user");

                entity.Property(e => e.SendDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("send_datetime");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("subject");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.ToTable("email_template");

                entity.Property(e => e.EmailTemplateId).HasColumnName("email_template_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EmailType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email_type");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("group_type");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("subject");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");
            });


            modelBuilder.Entity<SystemParameter>(entity =>
            {
                entity.ToTable("system_parameter");

                entity.Property(e => e.SystemParameterId).HasColumnName("system_parameter_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsEncrypted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_encrypted")
                    .IsFixedLength(true);

                entity.Property(e => e.ParameterCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("parameter_code");

                entity.Property(e => e.ParameterDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("parameter_description");

                entity.Property(e => e.ParameterType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("parameter_type");

                entity.Property(e => e.ParameterValue)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("parameter_value");

                entity.Property(e => e.ParameterValue2)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("parameter_value2");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");
            });


            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_system_user");

                entity.ToTable("system_users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.ChineseName)
                    .HasMaxLength(100)
                    .HasColumnName("chinese_name");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.EffectiveDateFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("effective_date_from");

                entity.Property(e => e.EffectiveDateTo)
                    .HasColumnType("datetime")
                    .HasColumnName("effective_date_to");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.HomePage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("home_page");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsReset)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_reset")
                    .IsFixedLength(true);

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_date");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mobile_no");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.NoOfFailure).HasColumnName("no_of_failure");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Post)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("post");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");

                entity.Property(e => e.UserUnit)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("user_unit");
            });
            modelBuilder.Entity<SystemRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("system_role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("role_name");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("unit");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");
            });

            modelBuilder.Entity<SystemRoleFunction>(entity =>
            {
                entity.HasKey(e => e.RoleFunctionId);

                entity.ToTable("system_role_function");

                entity.Property(e => e.RoleFunctionId).HasColumnName("role_function_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.DeleteFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("delete_flag")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength(true);

                entity.Property(e => e.EditFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("edit_flag")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength(true);

                entity.Property(e => e.EffDate)
                    .HasColumnType("datetime")
                    .HasColumnName("eff_date");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("expiry_date");

                entity.Property(e => e.FunctionNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("function_no");

                entity.Property(e => e.InsertFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("insert_flag")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");
            });

            modelBuilder.Entity<SystemUserRole>(entity =>
            {
                entity.ToTable("system_user_role");

                entity.Property(e => e.SystemUserRoleId).HasColumnName("system_user_role_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.EffDate)
                    .HasColumnType("date")
                    .HasColumnName("eff_date");

                entity.Property(e => e.ExpyDate)
                    .HasColumnType("date")
                    .HasColumnName("expy_date");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SystemUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_system_user_role_system_role");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
