﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubInvestorSetup.Models;

namespace SubInvestorSetup.Migrations
{
    [DbContext(typeof(InvestorContext))]
    [Migration("20190714043926_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SubInvestorSetup.Models.InvestorLink", b =>
                {
                    b.Property<int>("InvestorSetupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApprovedBy");

                    b.Property<DateTime>("ApprovedDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime>("DeletedDate");

                    b.Property<string>("DeletedReason")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("DeployedBy");

                    b.Property<DateTime>("DeployedDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<int>("InvestorNo");

                    b.Property<int>("InvestorSubFrom");

                    b.Property<int>("InvestorSubTo");

                    b.Property<int>("ModelAfterInvestorNo");

                    b.Property<int>("ModelAfterInvestorSub");

                    b.Property<int>("Status");

                    b.HasKey("InvestorSetupId");

                    b.ToTable("InvestorLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
