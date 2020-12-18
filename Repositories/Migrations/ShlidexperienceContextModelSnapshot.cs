﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.Data;

namespace Repositories.Migrations
{
    [DbContext(typeof(ShlidexperienceContext))]
    partial class ShlidexperienceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repositories.Data.OptionResultEntity", b =>
                {
                    b.Property<short>("SlideId")
                        .HasColumnType("smallint");

                    b.Property<Guid>("SlideOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SlideId", "SlideOptionId");

                    b.HasIndex("SlideOptionId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("OptionResults");
                });

            modelBuilder.Entity("Repositories.Data.PresentationEntity", b =>
                {
                    b.Property<int>("PresentationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PresentationId");

                    b.HasIndex("UserId");

                    b.ToTable("Presentations");
                });

            modelBuilder.Entity("Repositories.Data.SlideEntity", b =>
                {
                    b.Property<short>("SlideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Answered")
                        .HasColumnType("bit");

                    b.Property<int>("PresentationId")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<short>("SlideTypeId")
                        .HasColumnType("smallint");

                    b.HasKey("SlideId");

                    b.HasIndex("PresentationId");

                    b.HasIndex("SlideTypeId");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("Repositories.Data.SlideOptionEntity", b =>
                {
                    b.Property<Guid>("SlideOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfAnswers")
                        .HasColumnType("int");

                    b.Property<short>("SlideId")
                        .HasColumnType("smallint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("SlideOptionId");

                    b.HasIndex("SlideId");

                    b.ToTable("SlideOptions");
                });

            modelBuilder.Entity("Repositories.Data.SlideTypeEntity", b =>
                {
                    b.Property<short>("SlideTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("SlideTypeId");

                    b.ToTable("SlideTypes");

                    b.HasData(
                        new
                        {
                            SlideTypeId = (short)1,
                            Type = 1
                        },
                        new
                        {
                            SlideTypeId = (short)2,
                            Type = 2
                        });
                });

            modelBuilder.Entity("Repositories.Data.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("ResetKey")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("ResetKeyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("UserKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Repositories.Data.OptionResultEntity", b =>
                {
                    b.HasOne("Repositories.Data.SlideEntity", "Slide")
                        .WithMany()
                        .HasForeignKey("SlideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repositories.Data.SlideOptionEntity", "SlideOption")
                        .WithOne()
                        .HasForeignKey("Repositories.Data.OptionResultEntity", "SlideOptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Repositories.Data.UserEntity", "User")
                        .WithOne()
                        .HasForeignKey("Repositories.Data.OptionResultEntity", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Repositories.Data.PresentationEntity", b =>
                {
                    b.HasOne("Repositories.Data.UserEntity", "User")
                        .WithMany("Presentations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repositories.Data.SlideEntity", b =>
                {
                    b.HasOne("Repositories.Data.PresentationEntity", "Presentation")
                        .WithMany("Slides")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repositories.Data.SlideTypeEntity", "SlideType")
                        .WithMany()
                        .HasForeignKey("SlideTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repositories.Data.SlideOptionEntity", b =>
                {
                    b.HasOne("Repositories.Data.SlideEntity", "Slide")
                        .WithMany("SlideOptions")
                        .HasForeignKey("SlideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
