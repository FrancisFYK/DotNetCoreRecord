﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DotNetCoreRecord.Models;

namespace DotNetCoreRecord.Migrations
{
    [DbContext(typeof(DotNetCoreRecordContext))]
    [Migration("20170304045742_ColumnMapping")]
    partial class ColumnMapping
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetCoreRecord.Models.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("City")
                        .HasMaxLength(20);

                    b.Property<string>("Country")
                        .HasMaxLength(20);

                    b.Property<string>("District")
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(150);

                    b.Property<bool>("EmailChecked");

                    b.Property<string>("HeadUrl")
                        .HasMaxLength(200);

                    b.Property<string>("LastLoginIp")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastLoginTime");

                    b.Property<DateTime?>("LastWeixinSignInTime");

                    b.Property<string>("NickName")
                        .HasMaxLength(50);

                    b.Property<string>("Note");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PicUrl")
                        .HasMaxLength(200);

                    b.Property<string>("QQ")
                        .HasMaxLength(50);

                    b.Property<string>("RealName")
                        .HasMaxLength(50);

                    b.Property<int>("Sex");

                    b.Property<string>("Tel")
                        .HasMaxLength(50);

                    b.Property<string>("ThisLoginIp")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ThisLoginTime");

                    b.Property<int>("Type");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("WeixinOpenId")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasAlternateKey("Address");

                    b.HasIndex("Sex");

                    b.HasIndex("UserName");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DotNetCoreRecord.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.Property<string>("blog_type")
                        .IsRequired();

                    b.HasKey("BlogId");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Blogs");

                    b.HasDiscriminator<string>("blog_type").HasValue("blog_base");
                });

            modelBuilder.Entity("DotNetCoreRecord.Models.Persion", b =>
                {
                    b.Property<int>("PersionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("Sex")
                        .HasColumnName("sex");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PersionId");

                    b.ToTable("Persions");
                });

            modelBuilder.Entity("DotNetCoreRecord.Models.RssBlog", b =>
                {
                    b.HasBaseType("DotNetCoreRecord.Models.Blog");

                    b.Property<string>("RssUrl");

                    b.ToTable("RssBlog","RssBlog");

                    b.HasDiscriminator().HasValue("blog_rss");
                });
        }
    }
}
