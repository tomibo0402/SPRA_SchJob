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
        public virtual DbSet<SalesDocEmail> SalesDocEmails { get; set; }
        public virtual DbSet<CodeTable> CodeTables { get; set; }
        public virtual DbSet<ApeuLog> ApeuLogs { get; set; }
        public virtual DbSet<ApeuLogDoc> ApeuLogDocs { get; set; }
        public virtual DbSet<DevelopmentMaster> DevelopmentMasters { get; set; }
        public virtual DbSet<RegisterAdvertisement> RegisterAdvertisements { get; set; }
        public virtual DbSet<RegisterPriceList> RegisterPriceLists { get; set; }
        public virtual DbSet<RegisterSalesArrangement> RegisterSalesArrangements { get; set; }
        public virtual DbSet<RegisterSalesBrochure> RegisterSalesBrochures { get; set; }
        public virtual DbSet<RegisterShowFlat> RegisterShowFlats { get; set; }
        public virtual DbSet<RegisterTransactionMaster> RegisterTransactionMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=SRPA_MIS;User ID=HRTAIS_COUNCIL;Password=P@ssw0rd", options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<ApeuLog>(entity =>
            {
                entity.ToTable("apeu_log");

                entity.Property(e => e.ApeuLogId)
                    .ValueGeneratedNever()
                    .HasColumnName("apeu_log_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.DevelopmentId).HasColumnName("development_id");

                entity.Property(e => e.DevelopmentNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("development_no");

                entity.Property(e => e.ImuSendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("imu_send_flag")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.OpenDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("open_datetime");

                entity.Property(e => e.ReceivedFrom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("received_from");

                entity.Property(e => e.ReceivedSrpeDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("received_srpe_datetime");

                entity.Property(e => e.StampDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("stamp_datetime");

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("system_no");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");

                entity.Property(e => e.WebSites)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("web_sites")
                    .IsFixedLength(true);
            });
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

            modelBuilder.Entity<CodeTable>(entity =>
            {
                entity.HasKey(e => e.CodeId)
                    .HasName("PK__code_tab__9A4BCC0CA27A9094");

                entity.ToTable("code_table");

                entity.Property(e => e.CodeId).HasColumnName("code_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CodeDescriptionEng)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("code_description_eng");

                entity.Property(e => e.CodeMasterType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("code_master_type");

                entity.Property(e => e.CodeType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("code_type");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.GroupType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("group_type");

                entity.Property(e => e.IsDefault)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_default")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsSystemUse)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_system_use")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");
            });

            modelBuilder.Entity<DevelopmentMaster>(entity =>
            {
                entity.HasKey(e => e.DevelopmentId);

                entity.ToTable("development_master");

                entity.Property(e => e.DevelopmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("development_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.DevelopmentNameChi)
                    .HasMaxLength(200)
                    .HasColumnName("development_name_chi");

                entity.Property(e => e.DevelopmentNameEng)
                    .HasMaxLength(200)
                    .HasColumnName("development_name_eng");

                entity.Property(e => e.DevelopmentNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("development_no");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email_address");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fax_no");

                entity.Property(e => e.FirstDateSales)
                    .HasColumnType("date")
                    .HasColumnName("first_date_sales");

                entity.Property(e => e.HousingSchemeCode)
                    .HasMaxLength(50)
                    .HasColumnName("housing_scheme_code");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.PhaseNameChi)
                    .HasMaxLength(80)
                    .HasColumnName("phase_name_chi");

                entity.Property(e => e.PhaseNameEng)
                    .HasMaxLength(80)
                    .HasColumnName("phase_name_eng");

                entity.Property(e => e.PhaseNo)
                    .HasMaxLength(20)
                    .HasColumnName("phase_no");

                entity.Property(e => e.PhaseNoChi)
                    .HasMaxLength(20)
                    .HasColumnName("phase_no_chi");

                entity.Property(e => e.PlannedArea1)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("planned_area_1");

                entity.Property(e => e.PlannedArea2)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("planned_area_2");

                entity.Property(e => e.RoadName)
                    .HasMaxLength(50)
                    .HasColumnName("road_name");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength(true);

                entity.Property(e => e.StreetNoAlpha)
                    .HasMaxLength(50)
                    .HasColumnName("street_no_alpha");

                entity.Property(e => e.StreetNoExt)
                    .HasMaxLength(50)
                    .HasColumnName("street_no_ext");

                entity.Property(e => e.StreetNoNum).HasColumnName("street_no_num");

                entity.Property(e => e.SuspensionDate)
                    .HasColumnType("date")
                    .HasColumnName("suspension_date");

                entity.Property(e => e.TelNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tel_no");

                entity.Property(e => e.TerminationDate)
                    .HasColumnType("date")
                    .HasColumnName("termination_date");

                entity.Property(e => e.TotalNoOfUnits).HasColumnName("total_no_of_units");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");

                entity.Property(e => e.WebAddress)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("web_address");
            });

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

            modelBuilder.Entity<RegisterAdvertisement>(entity =>
            {
                entity.ToTable("register_advertisement");

                entity.Property(e => e.RegisterAdvertisementId).HasColumnName("register_advertisement_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.AdName)
                    .HasMaxLength(200)
                    .HasColumnName("ad_name");

                entity.Property(e => e.AdPublishByVendor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ad_publish_by_vendor");

                entity.Property(e => e.AdReviseFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ad_revise_flag")
                    .HasDefaultValueSql("('F')")
                    .IsFixedLength(true);

                entity.Property(e => e.AdType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ad_type");

                entity.Property(e => e.Aipo1UserId).HasColumnName("aipo1_user_id");

                entity.Property(e => e.Aipo2UserId).HasColumnName("aipo2_user_id");

                entity.Property(e => e.ApeuDocId).HasColumnName("apeu_doc_id");

                entity.Property(e => e.ApprovalDateCipo)
                    .HasColumnType("date")
                    .HasColumnName("approval_date_cipo");

                entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");

                entity.Property(e => e.CaseId).HasColumnName("case_id");

                entity.Property(e => e.CheckDateAipo1)
                    .HasColumnType("date")
                    .HasColumnName("check_date_aipo1");

                entity.Property(e => e.CheckDateAipo2)
                    .HasColumnType("date")
                    .HasColumnName("check_date_aipo2");

                entity.Property(e => e.CheckDateIpo1)
                    .HasColumnType("date")
                    .HasColumnName("check_date_ipo1");

                entity.Property(e => e.CheckDateIpo2)
                    .HasColumnType("date")
                    .HasColumnName("check_date_ipo2");

                entity.Property(e => e.CheckDateSipo2)
                    .HasColumnType("date")
                    .HasColumnName("check_date_sipo2");

                entity.Property(e => e.CipoUserId).HasColumnName("cipo_user_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.DevelopmentNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("development_no");

                entity.Property(e => e.DocRefNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("doc_ref_no");

                entity.Property(e => e.EndorsementDateSipo1)
                    .HasColumnType("date")
                    .HasColumnName("endorsement_date_sipo1");

                entity.Property(e => e.Ipo1UserId).HasColumnName("ipo1_user_id");

                entity.Property(e => e.Ipo2UserId).HasColumnName("ipo2_user_id");

                entity.Property(e => e.IsCompianceGuideline)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_compiance_guideline")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsCompianceOrdinance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_compiance_ordinance")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.PrintDate)
                    .HasColumnType("date")
                    .HasColumnName("print_date");

                entity.Property(e => e.ReferralDateIcau)
                    .HasColumnType("date")
                    .HasColumnName("referral_date_icau");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.RemarksReturn)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("remarks_return");

                entity.Property(e => e.SbAvailableDate)
                    .HasColumnType("date")
                    .HasColumnName("sb_available_date");

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("serial_no");

                entity.Property(e => e.Sipo1UserId).HasColumnName("sipo1_user_id");

                entity.Property(e => e.Sipo2UserId).HasColumnName("sipo2_user_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");

                entity.Property(e => e.UploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("upload_date");

                entity.Property(e => e.UploadUser).HasColumnName("upload_user");
            });

            modelBuilder.Entity<RegisterPriceList>(entity =>
            {
                entity.ToTable("register_price_list");

                entity.Property(e => e.RegisterPriceListId).HasColumnName("register_price_list_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.Aipo1UserId).HasColumnName("aipo1_user_id");

                entity.Property(e => e.Aipo2UserId).HasColumnName("aipo2_user_id");

                entity.Property(e => e.ApeuDocId).HasColumnName("apeu_doc_id");

                entity.Property(e => e.ApprovalDateCipo)
                    .HasColumnType("date")
                    .HasColumnName("approval_date_cipo");

                entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");

                entity.Property(e => e.AvailableDateSrpe)
                    .HasColumnType("date")
                    .HasColumnName("available_date_srpe");

                entity.Property(e => e.AvailableToPublic)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("available_to_public")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.CaseId).HasColumnName("case_id");

                entity.Property(e => e.CheckDateAipo1)
                    .HasColumnType("date")
                    .HasColumnName("check_date_aipo1");

                entity.Property(e => e.CheckDateAipo2)
                    .HasColumnType("date")
                    .HasColumnName("check_date_aipo2");

                entity.Property(e => e.CheckDateIpo1)
                    .HasColumnType("date")
                    .HasColumnName("check_date_ipo1");

                entity.Property(e => e.CheckDateIpo2)
                    .HasColumnType("date")
                    .HasColumnName("check_date_ipo2");

                entity.Property(e => e.CipoUserId).HasColumnName("cipo_user_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.DevelopmentNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("development_no");

                entity.Property(e => e.DocRefNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("doc_ref_no");

                entity.Property(e => e.EndorsementDateSipo1)
                    .HasColumnType("date")
                    .HasColumnName("endorsement_date_sipo1");

                entity.Property(e => e.EndorsementDateSipo2)
                    .HasColumnType("date")
                    .HasColumnName("endorsement_date_sipo2");

                entity.Property(e => e.FirstDateSales)
                    .HasColumnType("date")
                    .HasColumnName("first_date_sales");

                entity.Property(e => e.FirstPrintDate)
                    .HasColumnType("date")
                    .HasColumnName("first_print_date");

                entity.Property(e => e.Ipo1UserId).HasColumnName("ipo1_user_id");

                entity.Property(e => e.Ipo2UserId).HasColumnName("ipo2_user_id");

                entity.Property(e => e.IsComplianceGuideline)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_compliance_guideline")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsComplianceOrdinance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_compliance_ordinance")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsOtherRevised)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_other_revised")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsRevised)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_revised")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsVettingRequired)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_vetting_required")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.PlType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pl_type");

                entity.Property(e => e.ReceivedDateSrpa)
                    .HasColumnType("date")
                    .HasColumnName("received_date_srpa");

                entity.Property(e => e.ReceivedDateVendor)
                    .HasColumnType("date")
                    .HasColumnName("received_date_vendor");

                entity.Property(e => e.ReferralDateIcau)
                    .HasColumnType("date")
                    .HasColumnName("referral_date_icau");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.RemarksReturn)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("remarks_return");

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("serial_no");

                entity.Property(e => e.Sipo1UserId).HasColumnName("sipo1_user_id");

                entity.Property(e => e.Sipo2UserId).HasColumnName("sipo2_user_id");

                entity.Property(e => e.SiteInspectionBy).HasColumnName("site_inspection_by");

                entity.Property(e => e.SiteInspectionDate)
                    .HasColumnType("date")
                    .HasColumnName("site_inspection_date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");

                entity.Property(e => e.UploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("upload_date");

                entity.Property(e => e.UploadUser).HasColumnName("upload_user");
            });

            modelBuilder.Entity<RegisterSalesArrangement>(entity =>
            {
                entity.ToTable("register_sales_arrangement");

                entity.Property(e => e.RegisterSalesArrangementId).HasColumnName("register_sales_arrangement_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.Aipo1UserId).HasColumnName("aipo1_user_id");

                entity.Property(e => e.Aipo2UserId).HasColumnName("aipo2_user_id");

                entity.Property(e => e.ApeuDocId).HasColumnName("apeu_doc_id");

                entity.Property(e => e.ApprovalDateCipo)
                    .HasColumnType("date")
                    .HasColumnName("approval_date_cipo");

                entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");

                entity.Property(e => e.AvailableToPublic)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("available_to_public")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.CaseId).HasColumnName("case_id");

                entity.Property(e => e.CheckDateAipo1)
                    .HasColumnType("date")
                    .HasColumnName("check_date_aipo1");

                entity.Property(e => e.CheckDateAipo2)
                    .HasColumnType("date")
                    .HasColumnName("check_date_aipo2");

                entity.Property(e => e.CheckDateIpo1)
                    .HasColumnType("date")
                    .HasColumnName("check_date_ipo1");

                entity.Property(e => e.CheckDateIpo2)
                    .HasColumnType("date")
                    .HasColumnName("check_date_ipo2");

                entity.Property(e => e.CipoUserId).HasColumnName("cipo_user_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.DevelopmentNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("development_no");

                entity.Property(e => e.DocRefNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("doc_ref_no");

                entity.Property(e => e.EndorsementDateSipo1)
                    .HasColumnType("date")
                    .HasColumnName("endorsement_date_sipo1");

                entity.Property(e => e.EndorsementDateSipo2)
                    .HasColumnType("date")
                    .HasColumnName("endorsement_date_sipo2");

                entity.Property(e => e.FirstDateSales)
                    .HasColumnType("date")
                    .HasColumnName("first_date_sales");

                entity.Property(e => e.FirstPrintDate)
                    .HasColumnType("date")
                    .HasColumnName("first_print_date");

                entity.Property(e => e.Ipo1UserId).HasColumnName("ipo1_user_id");

                entity.Property(e => e.Ipo2UserId).HasColumnName("ipo2_user_id");

                entity.Property(e => e.IsComplianceGuideline)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_compliance_guideline")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsComplianceOrdinance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_compliance_ordinance")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsSuspensionOnly)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_suspension_only")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IssuingDate)
                    .HasColumnType("date")
                    .HasColumnName("issuing_date");

                entity.Property(e => e.ReferralDateIcau)
                    .HasColumnType("datetime")
                    .HasColumnName("referral_date_icau");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.RemarksReturn)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("remarks_return");

                entity.Property(e => e.SaType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sa_type");

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("serial_no");

                entity.Property(e => e.Sipo1UserId).HasColumnName("sipo1_user_id");

                entity.Property(e => e.Sipo2UserId).HasColumnName("sipo2_user_id");

                entity.Property(e => e.SiteInspectionBy).HasColumnName("site_inspection_by");

                entity.Property(e => e.SiteInspectionDate)
                    .HasColumnType("date")
                    .HasColumnName("site_inspection_date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.TenderPeriod)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("tender_period");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");

                entity.Property(e => e.UploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("upload_date");

                entity.Property(e => e.UploadUser).HasColumnName("upload_user");
            });

            modelBuilder.Entity<RegisterSalesBrochure>(entity =>
            {
                entity.ToTable("register_sales_brochure");

                entity.Property(e => e.RegisterSalesBrochureId).HasColumnName("register_sales_brochure_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.Aipo1UserId).HasColumnName("aipo1_user_id");

                entity.Property(e => e.Aipo2UserId).HasColumnName("aipo2_user_id");

                entity.Property(e => e.ApeuDocId).HasColumnName("apeu_doc_id");

                entity.Property(e => e.ApprovalDateCipo)
                    .HasColumnType("date")
                    .HasColumnName("approval_date_cipo");

                entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");

                entity.Property(e => e.AvailableDateSrpe)
                    .HasColumnType("date")
                    .HasColumnName("available_date_srpe");

                entity.Property(e => e.AvailableDateVendor)
                    .HasColumnType("date")
                    .HasColumnName("available_date_vendor");

                entity.Property(e => e.AvailableToPublic)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("available_to_public")
                    .IsFixedLength(true);

                entity.Property(e => e.CaseId).HasColumnName("case_id");

                entity.Property(e => e.CheckDateAipo1)
                    .HasColumnType("date")
                    .HasColumnName("check_date_aipo1");

                entity.Property(e => e.CheckDateAipo2)
                    .HasColumnType("date")
                    .HasColumnName("check_date_aipo2");

                entity.Property(e => e.CheckDateIpo1)
                    .HasColumnType("date")
                    .HasColumnName("check_date_ipo1");

                entity.Property(e => e.CheckDateIpo2)
                    .HasColumnType("date")
                    .HasColumnName("check_date_ipo2");

                entity.Property(e => e.CipoUserId).HasColumnName("cipo_user_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.DevelopmentNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("development_no");

                entity.Property(e => e.DocRefNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("doc_ref_no");

                entity.Property(e => e.EndorsementDateSipo1)
                    .HasColumnType("date")
                    .HasColumnName("endorsement_date_sipo1");

                entity.Property(e => e.EndorsementDateSipo2)
                    .HasColumnType("date")
                    .HasColumnName("endorsement_date_sipo2");

                entity.Property(e => e.ExaminationDate)
                    .HasColumnType("date")
                    .HasColumnName("examination_date");

                entity.Property(e => e.FirstDateSales)
                    .HasColumnType("date")
                    .HasColumnName("first_date_sales");

                entity.Property(e => e.FirstPrintDate)
                    .HasColumnType("date")
                    .HasColumnName("first_print_date");

                entity.Property(e => e.Ipo1UserId).HasColumnName("ipo1_user_id");

                entity.Property(e => e.Ipo2UserId).HasColumnName("ipo2_user_id");

                entity.Property(e => e.IsComplianceGuideline)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_compliance_guideline")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsComplianceOrdinance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_compliance_ordinance")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.NoOfListedProperties).HasColumnName("no_of_listed_properties");

                entity.Property(e => e.ReceivedDateSrpa)
                    .HasColumnType("date")
                    .HasColumnName("received_date_srpa");

                entity.Property(e => e.ReferralDateIcau)
                    .HasColumnType("datetime")
                    .HasColumnName("referral_date_icau");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.RemarksReturn)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("remarks_return");

                entity.Property(e => e.SbType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sb_type");

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("serial_no");

                entity.Property(e => e.Sipo1UserId).HasColumnName("sipo1_user_id");

                entity.Property(e => e.Sipo2UserId).HasColumnName("sipo2_user_id");

                entity.Property(e => e.SiteInspectionBy).HasColumnName("site_inspection_by");

                entity.Property(e => e.SiteInspectionDate)
                    .HasColumnType("date")
                    .HasColumnName("site_inspection_date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");

                entity.Property(e => e.UploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("upload_date");

                entity.Property(e => e.UploadUser).HasColumnName("upload_user");
            });

            modelBuilder.Entity<RegisterShowFlat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("register_show_flat");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.ApprovalDateCipo)
                    .HasColumnType("date")
                    .HasColumnName("approval_date_cipo");

                entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");

                entity.Property(e => e.AvailableDate)
                    .HasColumnType("date")
                    .HasColumnName("available_date");

                entity.Property(e => e.CaseId).HasColumnName("case_id");

                entity.Property(e => e.CheckingCompletionDate)
                    .HasColumnType("date")
                    .HasColumnName("checking_completion_date");

                entity.Property(e => e.CipoUserId).HasColumnName("cipo_user_id");

                entity.Property(e => e.CompleteDateIcau)
                    .HasColumnType("date")
                    .HasColumnName("complete_date_icau");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.DateReportSipo)
                    .HasColumnType("date")
                    .HasColumnName("date_report_sipo");

                entity.Property(e => e.DevelopmentNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("development_no");

                entity.Property(e => e.DocRefNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("doc_ref_no");

                entity.Property(e => e.FloorNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("floor_no");

                entity.Property(e => e.FurtherChecking)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("further_checking");

                entity.Property(e => e.FurtherCheckingDate)
                    .HasColumnType("date")
                    .HasColumnName("further_checking_date");

                entity.Property(e => e.InspectionId).HasColumnName("inspection_id");

                entity.Property(e => e.IsAvailableForView)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_available_for_view")
                    .IsFixedLength(true);

                entity.Property(e => e.IsComplianceGuideline)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_compliance_guideline")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsComplianceOrdinance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_compliance_ordinance")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.OnSiteCheckingDate)
                    .HasColumnType("date")
                    .HasColumnName("on_site_checking_date");

                entity.Property(e => e.RegisterShowFlatId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("register_show_flat_id");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.RemarksReturn)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("remarks_return");

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("serial_no");

                entity.Property(e => e.ShowFlatLocation)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("show_flat_location");

                entity.Property(e => e.ShowFlatNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("show_flat_no");

                entity.Property(e => e.ShowFlatScale)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("show_flat_scale");

                entity.Property(e => e.SipoUserId).HasColumnName("sipo_user_id");

                entity.Property(e => e.SiteInspectionBy).HasColumnName("site_inspection_by");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.Unit)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("unit");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");

                entity.Property(e => e.UploadDate)
                    .HasColumnType("date")
                    .HasColumnName("upload_date");

                entity.Property(e => e.UploadUser).HasColumnName("upload_user");

                entity.Property(e => e.VendorContact)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("vendor_contact");
            });

            modelBuilder.Entity<RegisterTransactionMaster>(entity =>
            {
                entity.ToTable("register_transaction_master");

                entity.Property(e => e.RegisterTransactionMasterId)
                    .ValueGeneratedNever()
                    .HasColumnName("register_transaction_master_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.ApeuDocId).HasColumnName("apeu_doc_id");

                entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.DevelopmentNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("development_no");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("serial_no");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUser).HasColumnName("update_user");

                entity.Property(e => e.UploadDate)
                    .HasColumnType("date")
                    .HasColumnName("upload_date");

                entity.Property(e => e.UploadUser).HasColumnName("upload_user");
            });

            modelBuilder.Entity<SalesDocEmail>(entity =>
            {
                entity.ToTable("sales_doc_email");

                entity.Property(e => e.SalesDocEmailId).HasColumnName("sales_doc_email_id");

                entity.Property(e => e.ActionId)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("action_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUser).HasColumnName("create_user");

                entity.Property(e => e.DocType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("doc_type");

                entity.Property(e => e.EmailTemplateId).HasColumnName("email_template_id");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.SendToPost)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("send_to_post");

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

            modelBuilder.Entity<SystemRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("system_role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

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

                entity.Property(e => e.Rank)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("rank");

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
            modelBuilder.HasSequence("seq_apeu log");

            modelBuilder.HasSequence("seq_apeu_system_no");

            modelBuilder.HasSequence("seq_case_contact");

            modelBuilder.HasSequence("seq_case_master");

            modelBuilder.HasSequence("seq_case_no");

            modelBuilder.HasSequence("seq_checklist_master");

            modelBuilder.HasSequence("seq_development_master");

            modelBuilder.HasSequence("seq_development_no");

            modelBuilder.HasSequence("seq_disposal_batch_no");

            modelBuilder.HasSequence("seq_disposal_master");

            modelBuilder.HasSequence("seq_inspection");

            modelBuilder.HasSequence("seq_inspection_no");

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
