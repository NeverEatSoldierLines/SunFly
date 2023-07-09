using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NovelRepositories.Entities;

public class Chapter
{
    public int ChapterId { get; set; }

    public string? ChapterName { get; set; }

    /// <summary>
    /// 章节速记
    /// </summary>
    public string? Shorthand { get; set; }

    /// <summary>
    /// 章节内容
    /// </summary>
    public string? Content { get; set; }
    

    /// <summary>
    /// 所属小说,导航属性
    /// </summary>
    [ForeignKey("NovelId")]
    public Novel? BelongsNovel { get; set; }
    

    public int NovelId { get; set; }

    /// <summary>
    /// 外键
    /// </summary>
    public int BelongsNovelId { get; set; }
}