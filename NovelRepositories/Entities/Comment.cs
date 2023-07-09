
namespace NovelRepositories.Entities;

public class ChapterComment
{
    public int  ChapterCommentId { get; set; }

    /// <summary>
    /// 评论者ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// 评论内容
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 评论发布时间
    /// </summary>
    public DateTime PublishTime { get; set; }

    /// <summary>
    /// 该评论所属的文章章节
    /// </summary>
    public Chapter? BelongsChapter { get; set; }
}

public class PostComment
{
    public int  PostCommentId { get; set; }

    /// <summary>
    /// 评论者ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// 评论内容
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 评论发布时间
    /// </summary>
    public DateTime PublishTime { get; set; }

    /// <summary>
    /// 该评论所属的帖子
    /// </summary>
    public Post? BelongsPost { get; set; }
}

public class NovelComment
{
    public int  NovelCommentId { get; set; }

    /// <summary>
    /// 评论者ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// 评论内容
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 评论发布时间
    /// </summary>
    public DateTime PublishTime { get; set; }

    /// <summary>
    /// 该评论所属的帖子
    /// </summary>
    public Novel? BelongsNovel { get; set; }
}