namespace NovelRepositories.Entities;

/// <summary>
/// 站内帖
/// </summary>
public class Post
{
    public int PostId { get; set; }

    public string? PostName { get; set; }

    /// <summary>
    /// 主帖内容.其余跟帖全部属于评论
    /// </summary>
    public string? PostContent { get; set; }

    public DateTime PublishTime { get; set; }

    /// <summary>
    /// 所属者ID
    /// </summary>
    public User? BelongsUser { get; set; }
    
    /// <summary>
    /// 帖子状态:
    /// -1 被删除(作者或管理员或编辑删除)
    /// 0 正常
    /// 1 被推荐
    /// </summary>
    public int PostStatus { get; set; }
    
    /// <summary>
    /// 收藏数量
    /// </summary>
    public int FavoredNums { get; set; }
    
}