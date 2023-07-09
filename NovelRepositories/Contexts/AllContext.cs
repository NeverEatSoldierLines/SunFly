using Microsoft.EntityFrameworkCore;
using NovelRepositories.Entities;

namespace NovelRepositories.Contexts;

public class AllContext:DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    
    public DbSet<Chapter> Chapters { get; set; } = null!;
    
    public DbSet<ChapterComment> ChapterComments { get; set; } = null!;
    
    public DbSet<NovelComment> NovelComments { get; set; } = null!;
    
    public DbSet<Novel> Novels { get; set; } = null!;
    
    public DbSet<Post> Posts { get; set; } = null!;
    
    public DbSet<PostComment> PostComments { get; set; } = null!;
    
    public DbSet<AdminOperateRecord> AdminOperateRecords { get; set; } = null!;
    
    public DbSet<EditorOperateRecord> EditorOperateRecords { get; set; } = null!;

    public AllContext(DbContextOptions<AllContext> options)
    :base(options)
    {
    }
}