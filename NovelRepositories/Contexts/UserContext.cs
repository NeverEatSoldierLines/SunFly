using Microsoft.EntityFrameworkCore;
using NovelRepositories.Entities;

namespace NovelRepositories.Contexts;

/// <summary>
/// 用来用户与非文章、帖子相关的数据的操作
/// </summary>
public class UserContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    
    public DbSet<Novel>? Novels { get; set; }
    
    public DbSet<Post>? Posts { get; set; }
    
    public DbSet<Chapter>? Chapters { get; set; }
    
    public DbSet<ChapterComment>? ChapterComments { get; set; }
    
    public DbSet<NovelComment>? NovelComments { get; set; }
    
    public DbSet<PostComment>? PostComments { get; set; }

    public UserContext(DbContextOptions<UserContext> options)
    : base(options)
    {
        
    }
}