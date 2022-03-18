using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class abc : DbContext
    {
        public abc()
        {
        }

        public abc(DbContextOptions<abc> options)
            : base(options)
        {
        }

        public virtual DbSet<ApeuLogDoc> ApeuLogDocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=SRPA_MIS;User ID=HRTAIS_COUNCIL;Password=P@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<ApeuLogDoc>(entity =>
            {
                entity.HasKey(e => e.ApeuDocId);

                entity.ToTable("apeu_log_doc");

                entity.Property(e => e.ApeuDocId).HasColumnName("apeu_doc_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.ApeuLogId).HasColumnName("apeu_log_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.Date1)
                    .HasColumnType("date")
                    .HasColumnName("date1");

                entity.Property(e => e.Date2)
                    .HasColumnType("date")
                    .HasColumnName("date2");

                entity.Property(e => e.DocName)
                    .HasMaxLength(200)
                    .HasColumnName("doc_name");

                entity.Property(e => e.DocRef)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("doc_ref");

                entity.Property(e => e.DocRef2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("doc_ref2");

                entity.Property(e => e.DocSeq)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("doc_seq");

                entity.Property(e => e.DocType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("doc_type");

                entity.Property(e => e.FirstDateSales)
                    .HasColumnType("date")
                    .HasColumnName("first_date_sales");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsEmailSent)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_email_sent")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.TotalNoOfUnits).HasColumnName("total_no_of_units");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");
            });

            modelBuilder.HasSequence("seq_apeu log");

            modelBuilder.HasSequence("seq_apeu_system_no");

            modelBuilder.HasSequence("seq_case_contact");

            modelBuilder.HasSequence("seq_case_master");

            modelBuilder.HasSequence("seq_case_no");

            modelBuilder.HasSequence("seq_checklist_master");

            modelBuilder.HasSequence("seq_development_master");

            modelBuilder.HasSequence("seq_development_no");

            modelBuilder.HasSequence("seq_disposal_master");

            modelBuilder.HasSequence("seq_inspection");

            modelBuilder.HasSequence("seq_password_history");

            modelBuilder.HasSequence("seq_price_list_master");

            modelBuilder.HasSequence("seq_radv_number");

            modelBuilder.HasSequence("seq_register_transaction_master");

            modelBuilder.HasSequence("seq_role");

            modelBuilder.HasSequence("seq_rpl_number");

            modelBuilder.HasSequence("seq_rrt_number");

            modelBuilder.HasSequence("seq_rsa_number");

            modelBuilder.HasSequence("seq_rsb_number");

            modelBuilder.HasSequence("seq_rsf_number");

            modelBuilder.HasSequence("seq_sales_arrangement_master");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
