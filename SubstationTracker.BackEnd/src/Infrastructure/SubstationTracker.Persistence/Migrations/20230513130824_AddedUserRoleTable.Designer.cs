﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SubstationTracker.Persistence.DataContexts;

#nullable disable

namespace SubstationTracker.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230513130824_AddedUserRoleTable")]
    partial class AddedUserRoleTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SubstationTracker.Domain.Abstractions.Audits.Audit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<string>("Table")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Abstractions.Audits.CreateAudit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uuid")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.HasIndex("CreatedById");

                    b.ToTable("CreateAudits");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Abstractions.Audits.DeleteAudit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.HasIndex("DeletedById");

                    b.ToTable("DeleteAudits");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Abstractions.Audits.UpdateAudit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<string>("AfterColumnData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("BeforeColumnData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UpdatedById")
                        .HasColumnType("uuid")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("UpdateAudits");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Products.OtherDomains.ProductSector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnOrder(4);

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(2);

                    b.Property<Guid>("SectorId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.HasIndex("SectorId");

                    b.ToTable("ProductSectors");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnOrder(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(3);

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Sectors.Sector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnOrder(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers.SubstationResponsibleUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnOrder(4);

                    b.Property<Guid>("ResponsibleUserId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(3);

                    b.Property<Guid>("SubstationId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.HasIndex("ResponsibleUserId");

                    b.HasIndex("SubstationId");

                    b.ToTable("SubstationResponsibleUsers");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors.SubstationSector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnOrder(4);

                    b.Property<Guid>("SectorId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(3);

                    b.Property<Guid>("SubstationId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.HasIndex("SectorId");

                    b.HasIndex("SubstationId");

                    b.ToTable("SubstationSectors");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Substations._Bases.Substation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(4);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("")
                        .HasColumnOrder(5);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnOrder(7);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(3);

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.ToTable("Substations");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.UserLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsSuccess")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnOrder(5);

                    b.Property<string>("Parameters")
                        .HasColumnType("text")
                        .HasColumnOrder(4);

                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnOrder(3);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("UserLogs");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserResetPasswords.UserResetPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(3);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserResetPasswords");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnOrder(4);

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnOrder(3);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens.UserToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(3);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.UserVerification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(4);

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(6);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnOrder(7);

                    b.Property<bool>("IsUsed")
                        .HasColumnType("boolean")
                        .HasColumnOrder(5);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(2);

                    b.Property<int>("VerificationType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("UserVerifications");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users._Bases.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuditId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnOrder(6);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(4);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(3);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(5);

                    b.HasKey("Id");

                    b.HasIndex("AuditId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Abstractions.Audits.CreateAudit", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("CreateAudit")
                        .HasForeignKey("SubstationTracker.Domain.Abstractions.Audits.CreateAudit", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Users._Bases.User", "CreatedUser")
                        .WithMany("CreateAudits")
                        .HasForeignKey("CreatedById");

                    b.Navigation("Audit");

                    b.Navigation("CreatedUser");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Abstractions.Audits.DeleteAudit", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("DeleteAudit")
                        .HasForeignKey("SubstationTracker.Domain.Abstractions.Audits.DeleteAudit", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Users._Bases.User", "DeletedUser")
                        .WithMany("DeleteAudits")
                        .HasForeignKey("DeletedById");

                    b.Navigation("Audit");

                    b.Navigation("DeletedUser");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Abstractions.Audits.UpdateAudit", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithMany("UpdateAudits")
                        .HasForeignKey("AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Users._Bases.User", "UpdatedUser")
                        .WithMany("UpdateAudits")
                        .HasForeignKey("UpdatedById");

                    b.Navigation("Audit");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Products.OtherDomains.ProductSector", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("ProductSector")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Products.OtherDomains.ProductSector", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Products.Product", "Product")
                        .WithMany("ProductSectors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Sectors.Sector", "Sector")
                        .WithMany("ProductSectors")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");

                    b.Navigation("Product");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Products.Product", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("Product")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Products.Product", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Sectors.Sector", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("Sector")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Sectors.Sector", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers.SubstationResponsibleUser", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("SubstationResponsibleUser")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers.SubstationResponsibleUser", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Users._Bases.User", "ResponsibleUser")
                        .WithMany("SubstationResponsibleUsers")
                        .HasForeignKey("ResponsibleUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Substations._Bases.Substation", "Substation")
                        .WithMany("SubstationResponsibleUsers")
                        .HasForeignKey("SubstationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");

                    b.Navigation("ResponsibleUser");

                    b.Navigation("Substation");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors.SubstationSector", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("SubstationSector")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors.SubstationSector", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Sectors.Sector", "Sector")
                        .WithMany("SubstationSectors")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Substations._Bases.Substation", "Substation")
                        .WithMany("SubstationSectors")
                        .HasForeignKey("SubstationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");

                    b.Navigation("Sector");

                    b.Navigation("Substation");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Substations._Bases.Substation", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("Substation")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Substations._Bases.Substation", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.UserLog", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("UserLog")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.UserLog", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Users._Bases.User", "User")
                        .WithMany("UserLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserResetPasswords.UserResetPassword", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Concrete.Users._Bases.User", "User")
                        .WithOne("ResetPassword")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserResetPasswords.UserResetPassword", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.UserRole", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("UserRole")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.UserRole", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Users._Bases.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens.UserToken", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Concrete.Users._Bases.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens.UserToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.UserVerification", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("UserVerification")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.UserVerification", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SubstationTracker.Domain.Concrete.Users._Bases.User", "User")
                        .WithMany("UserVerifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users._Bases.User", b =>
                {
                    b.HasOne("SubstationTracker.Domain.Abstractions.Audits.Audit", "Audit")
                        .WithOne("User")
                        .HasForeignKey("SubstationTracker.Domain.Concrete.Users._Bases.User", "AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Abstractions.Audits.Audit", b =>
                {
                    b.Navigation("CreateAudit");

                    b.Navigation("DeleteAudit");

                    b.Navigation("Product");

                    b.Navigation("ProductSector");

                    b.Navigation("Sector");

                    b.Navigation("Substation");

                    b.Navigation("SubstationResponsibleUser");

                    b.Navigation("SubstationSector");

                    b.Navigation("UpdateAudits");

                    b.Navigation("User");

                    b.Navigation("UserLog");

                    b.Navigation("UserRole");

                    b.Navigation("UserVerification");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Products.Product", b =>
                {
                    b.Navigation("ProductSectors");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Sectors.Sector", b =>
                {
                    b.Navigation("ProductSectors");

                    b.Navigation("SubstationSectors");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Substations._Bases.Substation", b =>
                {
                    b.Navigation("SubstationResponsibleUsers");

                    b.Navigation("SubstationSectors");
                });

            modelBuilder.Entity("SubstationTracker.Domain.Concrete.Users._Bases.User", b =>
                {
                    b.Navigation("CreateAudits");

                    b.Navigation("DeleteAudits");

                    b.Navigation("RefreshToken");

                    b.Navigation("ResetPassword");

                    b.Navigation("SubstationResponsibleUsers");

                    b.Navigation("UpdateAudits");

                    b.Navigation("UserLogs");

                    b.Navigation("UserRoles");

                    b.Navigation("UserVerifications");
                });
#pragma warning restore 612, 618
        }
    }
}
