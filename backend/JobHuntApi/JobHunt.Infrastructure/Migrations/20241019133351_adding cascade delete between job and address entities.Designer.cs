﻿// <auto-generated />
using System;
using JobHunt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JobHunt.Infrastructure.Migrations
{
    [DbContext(typeof(JobHuntDbContext))]
    [Migration("20241019133351_adding cascade delete between job and address entities")]
    partial class addingcascadedeletebetweenjobandaddressentities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JobHunt.Domain.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street");

                    b.HasKey("Id");

                    b.ToTable("addresses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("76e24589-638c-4cb9-9970-675a263a7a43"),
                            City = "New York",
                            Country = "USA ",
                            Street = "street address 1"
                        });
                });

            modelBuilder.Entity("JobHunt.Domain.Models.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("company_name");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("position");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("Responsibility")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("responsibility");

                    b.Property<DateTime>("WorkFrom")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("work_from");

                    b.Property<DateTime>("WorkTo")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("work_to");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("experiences", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("257cf1f6-69d3-484b-a3b3-e60383afb8e9"),
                            CompanyName = "CompanyName",
                            Location = "Location",
                            Position = "Position",
                            ProfileId = new Guid("a51bd4f1-8501-405e-a634-bdb1d8bd8511"),
                            Responsibility = "Responsibility",
                            WorkFrom = new DateTime(2024, 10, 19, 13, 33, 51, 273, DateTimeKind.Utc).AddTicks(719),
                            WorkTo = new DateTime(2024, 10, 19, 13, 33, 51, 273, DateTimeKind.Utc).AddTicks(721)
                        },
                        new
                        {
                            Id = new Guid("027c906d-2e47-4f78-97da-35747551d30b"),
                            CompanyName = "CompanyName 2",
                            Location = "Location 2",
                            Position = "Position 2",
                            ProfileId = new Guid("a51bd4f1-8501-405e-a634-bdb1d8bd8511"),
                            Responsibility = "Responsibility 2",
                            WorkFrom = new DateTime(2024, 10, 19, 13, 33, 51, 273, DateTimeKind.Utc).AddTicks(727),
                            WorkTo = new DateTime(2024, 10, 19, 13, 33, 51, 273, DateTimeKind.Utc).AddTicks(728)
                        },
                        new
                        {
                            Id = new Guid("d6a1de3a-ae10-4949-9dc8-0b9aad0136f7"),
                            CompanyName = "CompanyName 3",
                            Location = "Location 3",
                            Position = "Position 3",
                            ProfileId = new Guid("a51bd4f1-8501-405e-a634-bdb1d8bd8511"),
                            Responsibility = "Responsibility 3",
                            WorkFrom = new DateTime(2024, 10, 19, 13, 33, 51, 273, DateTimeKind.Utc).AddTicks(747),
                            WorkTo = new DateTime(2024, 10, 19, 13, 33, 51, 273, DateTimeKind.Utc).AddTicks(747)
                        });
                });

            modelBuilder.Entity("JobHunt.Domain.Models.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("company_name");

                    b.Property<string>("ContractType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contract_type");

                    b.Property<string>("JobLevel")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("job_level");

                    b.Property<string>("OperationMode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("operation_mode");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("requirements");

                    b.Property<string>("Responsibilities")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("responsibilities");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("jobs", (string)null);
                });

            modelBuilder.Entity("JobHunt.Domain.Models.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<string>("Avatar")
                        .HasColumnType("text")
                        .HasColumnName("avatar");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("profiles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a51bd4f1-8501-405e-a634-bdb1d8bd8511"),
                            AddressId = new Guid("76e24589-638c-4cb9-9970-675a263a7a43"),
                            Avatar = "avatar.jpg",
                            DateOfBirth = new DateTime(2024, 10, 19, 13, 33, 51, 274, DateTimeKind.Utc).AddTicks(1815),
                            Email = "john@doe.com",
                            Lastname = "Doe",
                            Name = "John ",
                            Phone = "123456789"
                        });
                });

            modelBuilder.Entity("JobHunt.Domain.Models.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("education_level");

                    b.Property<string>("FieldOfStudy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("field_of_study");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid")
                        .HasColumnName("profile_id");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("specialization");

                    b.Property<DateTime>("StudyFrom")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("study_from");

                    b.Property<DateTime>("StudyTo")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("study_to");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("university_name");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("universities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("0d24c05c-e75d-4762-9080-28ee72f4993f"),
                            EducationLevel = "Bachelor",
                            FieldOfStudy = "Field of Study",
                            ProfileId = new Guid("a51bd4f1-8501-405e-a634-bdb1d8bd8511"),
                            Specialization = "Computer Science",
                            StudyFrom = new DateTime(2024, 10, 19, 13, 33, 51, 274, DateTimeKind.Utc).AddTicks(4939),
                            StudyTo = new DateTime(2024, 10, 19, 13, 33, 51, 274, DateTimeKind.Utc).AddTicks(4941),
                            UniversityName = "Vistula"
                        },
                        new
                        {
                            Id = new Guid("5f36f1c6-73c8-4abd-9509-61616916677b"),
                            EducationLevel = "Bachelor 2",
                            FieldOfStudy = "Field of Study 2",
                            ProfileId = new Guid("a51bd4f1-8501-405e-a634-bdb1d8bd8511"),
                            Specialization = "Computer Science 2",
                            StudyFrom = new DateTime(2024, 10, 19, 13, 33, 51, 274, DateTimeKind.Utc).AddTicks(4948),
                            StudyTo = new DateTime(2024, 10, 19, 13, 33, 51, 274, DateTimeKind.Utc).AddTicks(4948),
                            UniversityName = "Vistula 2"
                        },
                        new
                        {
                            Id = new Guid("972b81f2-b557-46f6-b879-6f4781b06df1"),
                            EducationLevel = "Bachelor 3",
                            FieldOfStudy = "Field of Study 3",
                            ProfileId = new Guid("a51bd4f1-8501-405e-a634-bdb1d8bd8511"),
                            Specialization = "Computer Science 3",
                            StudyFrom = new DateTime(2024, 10, 19, 13, 33, 51, 274, DateTimeKind.Utc).AddTicks(4953),
                            StudyTo = new DateTime(2024, 10, 19, 13, 33, 51, 274, DateTimeKind.Utc).AddTicks(4953),
                            UniversityName = "Vistula 3"
                        });
                });

            modelBuilder.Entity("JobHunt.Infrastructure.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("JobHunt.Domain.Models.Experience", b =>
                {
                    b.HasOne("JobHunt.Domain.Models.Profile", null)
                        .WithMany("Experiences")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobHunt.Domain.Models.Job", b =>
                {
                    b.HasOne("JobHunt.Domain.Models.Address", "Address")
                        .WithOne()
                        .HasForeignKey("JobHunt.Domain.Models.Job", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("JobHunt.Domain.Models.Profile", b =>
                {
                    b.HasOne("JobHunt.Domain.Models.Address", "Address")
                        .WithOne()
                        .HasForeignKey("JobHunt.Domain.Models.Profile", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("JobHunt.Domain.Models.University", b =>
                {
                    b.HasOne("JobHunt.Domain.Models.Profile", null)
                        .WithMany("Universities")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobHunt.Domain.Models.Profile", b =>
                {
                    b.Navigation("Experiences");

                    b.Navigation("Universities");
                });
#pragma warning restore 612, 618
        }
    }
}