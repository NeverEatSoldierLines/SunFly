using Microsoft.EntityFrameworkCore;
using NovelRepositories.Entities;

namespace NovelRepositories.Contexts;

/// <summary>
/// 编辑组成员的相关操作
/// </summary>
public class EditorContext : DbContext
{
    public DbSet<User>? Users { get; set; }

    public DbSet<EditorOperateRecord>? EditorOperateRecords { get; set; }
    
    public DbSet<Novel>? Novels { get; set; }
    
    public DbSet<Post>? Posts { get; set; }
    
    public DbSet<Chapter>? Chapters { get; set; }

    public EditorContext(DbContextOptions<EditorContext> options)
    : base(options)
    {
        
    }
}