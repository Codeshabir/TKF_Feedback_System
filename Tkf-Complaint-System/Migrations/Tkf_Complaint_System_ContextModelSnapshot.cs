﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tkf_Complaint_System.Data;

#nullable disable

namespace Tkf_Complaint_System.Migrations
{
    [DbContext(typeof(Tkf_Complaint_System_Context))]
    partial class Tkf_Complaint_System_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Tkf_Complaint_System.Areas.Identity.Data.Tkf_Complaint_SystemUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("DistrictId");

                    b.ToTable("cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "Karachi",
                            DistrictId = 1
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Quetta",
                            DistrictId = 2
                        });
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.ClientInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgeGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNIC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CallBackMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OthersCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isDirectBeneficiary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("clientInformation");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.DirectoryViewModel.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeptSubTypeId")
                        .HasColumnType("int");

                    b.Property<string>("OfficialEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficialPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficialWebsite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeptSubTypeId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.DirectoryViewModel.DepartmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dpt_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DepartmentType");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.DirectoryViewModel.DeptSubType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("SubType_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentTypeId");

                    b.ToTable("DeptSubType");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.DirectoryViewModel.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.District", b =>
                {
                    b.Property<int>("DistrictId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DistrictId"));

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("DistrictId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("districts");

                    b.HasData(
                        new
                        {
                            DistrictId = 1,
                            DistrictName = "Karachi",
                            ProvinceId = 2
                        },
                        new
                        {
                            DistrictId = 2,
                            DistrictName = "Quetta",
                            ProvinceId = 1
                        });
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("ComplaintDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ComplaintFeedbackRemarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedBackPriority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedbackByAdmin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FeedbackResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("SubType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.ToTable("feedbacks");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.FeedbackSubtypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedbackSubtype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FeedbackTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackTypeId");

                    b.ToTable("feedbackSubtypes");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.FeedbackTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedbackType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("feedbackTypes");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VillageId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("VillageId");

                    b.ToTable("projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            ProjectName = "UNICEF - KHI",
                            VillageId = 1
                        },
                        new
                        {
                            ProjectId = 2,
                            ProjectName = "UNICEF - Quetta",
                            VillageId = 2
                        });
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Project_tbl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Donor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectDistrict")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectUC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VillageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("project_Tbls");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Province", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProvinceId"));

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinceId");

                    b.ToTable("provinces");

                    b.HasData(
                        new
                        {
                            ProvinceId = 1,
                            ProvinceName = "Baluchistan"
                        },
                        new
                        {
                            ProvinceId = 2,
                            ProvinceName = "Sindh"
                        });
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("statuses");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.UC", b =>
                {
                    b.Property<int>("UCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UCId"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("UCName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UCId");

                    b.HasIndex("CityId");

                    b.ToTable("uCs");

                    b.HasData(
                        new
                        {
                            UCId = 1,
                            CityId = 1,
                            UCName = "North Karachi"
                        },
                        new
                        {
                            UCId = 2,
                            CityId = 2,
                            UCName = "Quetta Mariabad"
                        });
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Village", b =>
                {
                    b.Property<int>("VillageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VillageId"));

                    b.Property<int>("UCId")
                        .HasColumnType("int");

                    b.Property<string>("VillageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VillageId");

                    b.HasIndex("UCId");

                    b.ToTable("villages");

                    b.HasData(
                        new
                        {
                            VillageId = 1,
                            UCId = 1,
                            VillageName = "Village1"
                        },
                        new
                        {
                            VillageId = 2,
                            UCId = 2,
                            VillageName = "Quetta Village"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Areas.Identity.Data.Tkf_Complaint_SystemUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Areas.Identity.Data.Tkf_Complaint_SystemUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tkf_Complaint_System.Areas.Identity.Data.Tkf_Complaint_SystemUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Areas.Identity.Data.Tkf_Complaint_SystemUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.City", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Models.District", "District")
                        .WithMany("cities")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.DirectoryViewModel.Department", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Models.DirectoryViewModel.DeptSubType", "DeptSubType")
                        .WithMany("Departments")
                        .HasForeignKey("DeptSubTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeptSubType");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.DirectoryViewModel.DeptSubType", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Models.DirectoryViewModel.DepartmentType", "DepartmentType")
                        .WithMany("DeptSubTypes")
                        .HasForeignKey("DepartmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartmentType");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.DirectoryViewModel.Person", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Models.DirectoryViewModel.Department", "Department")
                        .WithMany("Persons")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.District", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Models.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Feedback", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Models.ClientInformation", "ClientInformation")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tkf_Complaint_System.Models.Project_tbl", "Project")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tkf_Complaint_System.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientInformation");

                    b.Navigation("Project");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.FeedbackSubtypes", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Models.FeedbackTypes", "FeedbackType")
                        .WithMany("FeedbackSubtypes")
                        .HasForeignKey("FeedbackTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeedbackType");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Project", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Models.Village", "village")
                        .WithMany("projects")
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("village");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.UC", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Models.City", "City")
                        .WithMany("UCs")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Village", b =>
                {
                    b.HasOne("Tkf_Complaint_System.Models.UC", "uC")
                        .WithMany("villages")
                        .HasForeignKey("UCId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("uC");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.City", b =>
                {
                    b.Navigation("UCs");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.ClientInformation", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.DirectoryViewModel.Department", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.DirectoryViewModel.DepartmentType", b =>
                {
                    b.Navigation("DeptSubTypes");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.DirectoryViewModel.DeptSubType", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.District", b =>
                {
                    b.Navigation("cities");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.FeedbackTypes", b =>
                {
                    b.Navigation("FeedbackSubtypes");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Project_tbl", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Province", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.UC", b =>
                {
                    b.Navigation("villages");
                });

            modelBuilder.Entity("Tkf_Complaint_System.Models.Village", b =>
                {
                    b.Navigation("projects");
                });
#pragma warning restore 612, 618
        }
    }
}
