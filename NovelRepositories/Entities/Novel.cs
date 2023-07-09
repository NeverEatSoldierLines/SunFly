using System.ComponentModel.DataAnnotations.Schema;

namespace NovelRepositories.Entities;

public class Novel
{
    public int NovelId { get; set; }

    public string? NovelName { get; set; }

    /// <summary>
    /// 修改之前的小说名,可以给刚刚改名的小说提供检索帮助,避免刚改名的小说被埋没
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// 简短介绍
    /// </summary>
    public string? ShortDescription { get; set; }

    /// <summary>
    /// 详细介绍
    /// </summary>
    public string? DetailedDescription { get; set; }

    /// <summary>
    /// 小说标签,支持自定义和使用预定标签(刚上线只有自定义,后续会有专用标签)
    /// 使用json存储,取出之后再json解析
    /// </summary>
    public string? NovelTag { get; set; }

    /// <summary>
    /// 作者ID
    /// </summary>
    public int UserId { get; set; }

    // /// <summary>
    // /// 作者名,将需要频繁访问的属性直接放进小说表里,避免频繁联表查询  //使用视图解决
    // /// </summary>
    // public string AuthorName { get; set; }

    /// <summary>
    /// 收藏数量
    /// </summary>
    public int FavoredNums { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 最近修改书籍信息时间
    /// </summary>
    public DateTime LastAlterTime { get; set; }

    /// <summary>
    /// 读者评分
    /// </summary>
    public double Score { get; set; }

    /// <summary>
    /// 小说状态
    /// </summary>
    public int NovelStatus { get; set; }
}