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
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repositories.Data.PresentationEntity", b =>
                {
                    b.Property<int>("PresentationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<short>("SlidetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PresentationEntityPresentationId")
                        .HasColumnType("int");

                    b.Property<short>("SlideTypeId")
                        .HasColumnType("smallint");

                    b.HasKey("SlidetId");

                    b.HasIndex("PresentationEntityPresentationId");

                    b.HasIndex("SlideTypeId");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("Repositories.Data.SlideOptionEntity", b =>
                {
                    b.Property<short>("SlideOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.HasOne("Repositories.Data.PresentationEntity", null)
                        .WithMany("Slides")
                        .HasForeignKey("PresentationEntityPresentationId");

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
