﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NovelControllers.Contexts;

#nullable disable

namespace NovelControllers.Migrations
{
    [DbContext(typeof(AllContext))]
    partial class AllContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NovelRepositories.Entities.AdminOperateRecord", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("OperateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OperatorType")
                        .HasColumnType("int");

                    b.HasKey("RecordId");

                    b.ToTable("AdminOperateRecords");
                });

            modelBuilder.Entity("NovelRepositories.Entities.Chapter", b =>
                {
                    b.Property<int>("ChapterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BelongsNovelId")
                        .HasColumnType("int");

                    b.Property<string>("ChapterName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NovelId")
                        .HasColumnType("int");

                    b.Property<string>("Shorthand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ChapterId");

                    b.HasIndex("NovelId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("NovelRepositories.Entities.ChapterComment", b =>
                {
                    b.Property<int>("ChapterCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BelongsChapterChapterId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ChapterCommentId");

                    b.HasIndex("BelongsChapterChapterId");

                    b.ToTable("ChapterComments");
                });

            modelBuilder.Entity("NovelRepositories.Entities.EditorOperateRecord", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsResigned")
                        .HasColumnType("bit(1)");

                    b.Property<DateTime>("OperateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OperatorType")
                        .HasColumnType("int");

                    b.HasKey("RecordId");

                    b.ToTable("EditorOperateRecords");
                });

            modelBuilder.Entity("NovelRepositories.Entities.Novel", b =>
                {
                    b.Property<int>("NovelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DetailedDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FavoredNums")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastAlterTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("NovelName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NovelStatus")
                        .HasColumnType("int");

                    b.Property<string>("NovelTag")
                        .HasColumnType("longtext");

                    b.Property<double>("Score")
                        .HasColumnType("double");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NovelId");

                    b.ToTable("Novels");
                });

            modelBuilder.Entity("NovelRepositories.Entities.NovelComment", b =>
                {
                    b.Property<int>("NovelCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BelongsNovelNovelId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NovelCommentId");

                    b.HasIndex("BelongsNovelNovelId");

                    b.ToTable("NovelComments");
                });

            modelBuilder.Entity("NovelRepositories.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BelongsUserUserId")
                        .HasColumnType("int");

                    b.Property<int>("FavoredNums")
                        .HasColumnType("int");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PostStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PostId");

                    b.HasIndex("BelongsUserUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("NovelRepositories.Entities.PostComment", b =>
                {
                    b.Property<int>("PostCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BelongsPostPostId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostCommentId");

                    b.HasIndex("BelongsPostPostId");

                    b.ToTable("PostComments");
                });

            modelBuilder.Entity("NovelRepositories.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Collections")
                        .HasColumnType("longtext");

                    b.Property<int>("ColorStone")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Feather")
                        .HasColumnType("int");

                    b.Property<string>("Followed")
                        .HasColumnType("longtext");

                    b.Property<string>("Follows")
                        .HasColumnType("longtext");

                    b.Property<string>("HeadLink")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsVip")
                        .HasColumnType("bit(1)");

                    b.Property<int>("LastIp")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastLoginTime")
                        .HasColumnType("datetime(6)");

                    b.Property<ushort>("Level")
                        .HasColumnType("smallint unsigned");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SelfIntroduction")
                        .HasColumnType("longtext");

                    b.Property<ushort>("Status")
                        .HasColumnType("smallint unsigned");

                    b.Property<string>("TagList")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("WearTag")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NovelRepositories.Entities.Chapter", b =>
                {
                    b.HasOne("NovelRepositories.Entities.Novel", "BelongsNovel")
                        .WithMany()
                        .HasForeignKey("NovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BelongsNovel");
                });

            modelBuilder.Entity("NovelRepositories.Entities.ChapterComment", b =>
                {
                    b.HasOne("NovelRepositories.Entities.Chapter", "BelongsChapter")
                        .WithMany()
                        .HasForeignKey("BelongsChapterChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BelongsChapter");
                });

            modelBuilder.Entity("NovelRepositories.Entities.NovelComment", b =>
                {
                    b.HasOne("NovelRepositories.Entities.Novel", "BelongsNovel")
                        .WithMany()
                        .HasForeignKey("BelongsNovelNovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BelongsNovel");
                });

            modelBuilder.Entity("NovelRepositories.Entities.Post", b =>
                {
                    b.HasOne("NovelRepositories.Entities.User", "BelongsUser")
                        .WithMany()
                        .HasForeignKey("BelongsUserUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BelongsUser");
                });

            modelBuilder.Entity("NovelRepositories.Entities.PostComment", b =>
                {
                    b.HasOne("NovelRepositories.Entities.Post", "BelongsPost")
                        .WithMany()
                        .HasForeignKey("BelongsPostPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BelongsPost");
                });
#pragma warning restore 612, 618
        }
    }
}