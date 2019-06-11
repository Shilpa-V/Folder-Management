﻿// <auto-generated />
using System;
using FolderManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FolderManagement.Migrations
{
    [DbContext(typeof(FolderDbContext))]
    [Migration("20190608065822_UpdateForeignKeyInTestCase")]
    partial class UpdateForeignKeyInTestCase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FolderManagement.Models.Folder", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("ParentFolderId");

                    b.HasKey("FolderId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("FolderManagement.Models.TestCase", b =>
                {
                    b.Property<int>("TestCaseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FolderId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("StepCount");

                    b.Property<int>("TestCaseType");

                    b.HasKey("TestCaseId");

                    b.HasIndex("FolderId");

                    b.ToTable("TestCases");
                });

            modelBuilder.Entity("FolderManagement.Models.TestCase", b =>
                {
                    b.HasOne("FolderManagement.Models.Folder")
                        .WithMany("TestCases")
                        .HasForeignKey("FolderId");
                });
#pragma warning restore 612, 618
        }
    }
}
