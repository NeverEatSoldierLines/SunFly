using Microsoft.EntityFrameworkCore;
using NovelRepositories.Entities;

namespace NovelRepositories.Contexts;

/// <summary>
/// 管理组成员的相关操作
/// </summary>
public class AdminContext: DbContext
{
    public DbSet<User>? Users { get; set; }
    
    public DbSet<AdminOperateRecord>? AdminOperateRecords { get; set; }
    
    public DbSet<EditorOperateRecord>? EditorOperateRecords { get; set; }
    
    public DbSet<Novel>? Novels { get; set; }
    
    public DbSet<Post>? Posts { get; set; }
    
    public DbSet<Chapter>? Chapters { get; set; }
    
    public DbSet<ChapterComment>? ChapterComments { get; set; }
    
    public DbSet<NovelComment>? NovelComments { get; set; }
    
    public DbSet<PostComment>? PostComments { get; set; }

    public AdminContext(DbContextOptions<AdminContext> options)
    : base(options)
    {
        
    }
}