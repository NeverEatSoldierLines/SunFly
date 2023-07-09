using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NovelRepositories.DataInMemory;

public enum Tag
{
    /// <summary>
    /// 萌新
    /// </summary>
    NewUser,
    /// <summary>
    /// 老用户
    /// </summary>
    OriginalUser,
    /// <summary>
    /// 赞助者
    /// </summary>
    Sponsor,
    /// <summary>
    /// 被推荐的创作者
    /// </summary>
    GreatCreator,
    /// <summary>
    /// 管理组成员
    /// </summary>
    AdminGroupMember,
    /// <summary>
    /// 编辑组成员
    /// </summary>
    EditorGroupMember,
    /// <summary>
    /// 站长
    /// </summary>
    WebsiteMaster
}