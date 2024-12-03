﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepairMan.DataAccess;

#nullable disable

namespace RepairMan.DataAccess.Migrations
{
    [DbContext(typeof(RepairManContext))]
    [Migration("20230803211719_WorkshopState")]
    partial class WorkshopState
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RepairMan.DataClasses.Advertising.Advertisement", b =>
                {
                    b.Property<Guid>("AdvertisementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ContextId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Relevance")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("AdvertisementId");

                    b.HasIndex("ContextId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Advertising.AdvertisementContext", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("GeopositionId")
                        .HasColumnType("char(36)");

                    b.Property<float>("Range")
                        .HasColumnType("float");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("WorkshopCategoryId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("GeopositionId");

                    b.HasIndex("WorkshopCategoryId");

                    b.ToTable("AdvertisementContexts");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Common.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Common.Geoposition", b =>
                {
                    b.Property<Guid>("GeopositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("Latitude")
                        .HasColumnType("float");

                    b.Property<float>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("GeopositionId");

                    b.ToTable("Geoposition");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Common.IdentityDocument", b =>
                {
                    b.Property<Guid>("IdentityDocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Reference")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("IdentityDocumentId");

                    b.ToTable("IdentityDocuments");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Common.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Roles")
                        .HasColumnType("json");

                    b.HasKey("UserId");

                    b.HasIndex("ContactId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Motoring.Brand", b =>
                {
                    b.Property<Guid>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Motoring.Model", b =>
                {
                    b.Property<Guid>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("ModelId");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Motoring.Vehicle", b =>
                {
                    b.Property<Guid>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Color")
                        .HasColumnType("longtext");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("VehicleId");

                    b.HasIndex("ModelId");

                    b.HasIndex("UserId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.BrandSpecialization", b =>
                {
                    b.Property<Guid>("BrandSpecializationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("char(36)");

                    b.HasKey("BrandSpecializationId");

                    b.HasIndex("BrandId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("BrandSpecialization");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Diagnostic.Answer", b =>
                {
                    b.Property<Guid>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DiagnosticId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Response")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AnswerId");

                    b.HasIndex("DiagnosticId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Diagnostic.Diagnostic", b =>
                {
                    b.Property<Guid>("DiagnosticId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Confidence")
                        .HasColumnType("double");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("PronosticId")
                        .HasColumnType("char(36)");

                    b.HasKey("DiagnosticId");

                    b.HasIndex("PronosticId");

                    b.ToTable("Diagnostics");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Diagnostic.Pronostic", b =>
                {
                    b.Property<Guid>("PronosticId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("PronosticId");

                    b.ToTable("Pronostics");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Diagnostic.PronosticQuestion", b =>
                {
                    b.Property<Guid>("PronosticQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PronosticId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.HasKey("PronosticQuestionId");

                    b.HasIndex("PronosticId");

                    b.HasIndex("QuestionId");

                    b.ToTable("PronosticQuestions");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Diagnostic.Question", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AffirmativeAnswer")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsInitial")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NegativeAnswer")
                        .HasColumnType("longtext");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.ModelSpecialization", b =>
                {
                    b.Property<Guid>("ModelSpecializationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("char(36)");

                    b.HasKey("ModelSpecializationId");

                    b.HasIndex("ModelId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("ModelSpecialization");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Offer", b =>
                {
                    b.Property<Guid>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("AvailableFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("AvailableUntil")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Keywords")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("char(36)");

                    b.HasKey("OfferId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Workshop", b =>
                {
                    b.Property<Guid>("WorkshopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("DocumentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("GeopositionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("char(36)");

                    b.HasKey("WorkshopId");

                    b.HasIndex("ContactId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("GeopositionId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.WorkshopCategorization", b =>
                {
                    b.Property<Guid>("WorkshopCategorizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WorkshopCategoryId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("char(36)");

                    b.HasKey("WorkshopCategorizationId");

                    b.HasIndex("WorkshopCategoryId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("WorkshopCategorization");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.WorkshopCategory", b =>
                {
                    b.Property<Guid>("WorkshopCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Color")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("WorkshopCategoryId");

                    b.ToTable("WorkshopCategories");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.WorkshopProduct", b =>
                {
                    b.Property<Guid>("WorkshopProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("char(36)");

                    b.HasKey("WorkshopProductId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("WorkshopProducts");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Scoring.Qualification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Qualification");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Advertising.Advertisement", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Advertising.AdvertisementContext", "Context")
                        .WithMany("Advertisements")
                        .HasForeignKey("ContextId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Context");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Advertising.AdvertisementContext", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Common.Geoposition", "Geoposition")
                        .WithMany()
                        .HasForeignKey("GeopositionId");

                    b.HasOne("RepairMan.DataClasses.Repairing.WorkshopCategory", "WorkshopCategory")
                        .WithMany()
                        .HasForeignKey("WorkshopCategoryId");

                    b.Navigation("Geoposition");

                    b.Navigation("WorkshopCategory");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Common.User", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Common.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Motoring.Model", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Motoring.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Motoring.Vehicle", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Motoring.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairMan.DataClasses.Common.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.BrandSpecialization", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Motoring.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairMan.DataClasses.Repairing.Workshop", "Workshop")
                        .WithMany("BrandSpecializations")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Diagnostic.Answer", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Repairing.Diagnostic.Diagnostic", "Diagnostic")
                        .WithMany("Answers")
                        .HasForeignKey("DiagnosticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairMan.DataClasses.Repairing.Diagnostic.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnostic");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Diagnostic.Diagnostic", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Repairing.Diagnostic.Pronostic", "Pronostic")
                        .WithMany()
                        .HasForeignKey("PronosticId");

                    b.Navigation("Pronostic");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Diagnostic.PronosticQuestion", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Repairing.Diagnostic.Pronostic", "Pronostic")
                        .WithMany("Questions")
                        .HasForeignKey("PronosticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairMan.DataClasses.Repairing.Diagnostic.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pronostic");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.ModelSpecialization", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Motoring.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairMan.DataClasses.Repairing.Workshop", "Workshop")
                        .WithMany("ModelSpecializations")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Offer", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Repairing.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Workshop", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Common.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairMan.DataClasses.Common.IdentityDocument", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId");

                    b.HasOne("RepairMan.DataClasses.Common.Geoposition", "Geoposition")
                        .WithMany()
                        .HasForeignKey("GeopositionId");

                    b.HasOne("RepairMan.DataClasses.Common.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("Document");

                    b.Navigation("Geoposition");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.WorkshopCategorization", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Repairing.WorkshopCategory", "WorkshopCategory")
                        .WithMany()
                        .HasForeignKey("WorkshopCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairMan.DataClasses.Repairing.Workshop", "Workshop")
                        .WithMany("Categorization")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");

                    b.Navigation("WorkshopCategory");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.WorkshopProduct", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Repairing.Workshop", "Workshop")
                        .WithMany("Products")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Scoring.Qualification", b =>
                {
                    b.HasOne("RepairMan.DataClasses.Common.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairMan.DataClasses.Repairing.Workshop", "Workshop")
                        .WithMany("Qualifications")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Advertising.AdvertisementContext", b =>
                {
                    b.Navigation("Advertisements");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Common.User", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Motoring.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Diagnostic.Diagnostic", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Diagnostic.Pronostic", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("RepairMan.DataClasses.Repairing.Workshop", b =>
                {
                    b.Navigation("BrandSpecializations");

                    b.Navigation("Categorization");

                    b.Navigation("ModelSpecializations");

                    b.Navigation("Products");

                    b.Navigation("Qualifications");
                });
#pragma warning restore 612, 618
        }
    }
}
