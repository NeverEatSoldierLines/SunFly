using NovelRepositories.DataInMemory;

namespace NovelRepositories.Entities;

public class User
{
    public int UserId { get; set; }
    
    /// <summary>
    /// 登陆使用username, username唯一
    /// </summary>
    public string? Username { get; set; }
    
    public string? Email { get; set; }

    public string? PwdToken { get; set; }
    
        /// <summary>
    /// 头像图片链接
    /// </summary>
    public string? HeadLink { get; set; }
    
    /// <summary>
    /// 注册时间
    /// </summary>
    public DateTime RegisterTime { get; set; }

    /// <summary>
    /// 登陆时间, 每次登陆计算用户注册时长, 决定授予的头衔和等级
    /// </summary>
    public DateTime LastLoginTime { get; set; }

    /// <summary>
    /// 存储用户上一次登陆的ip信息, 存储在数据库里使用int类型,可以减少空间和传输时间
    /// </summary>
    public uint LastIp { get; set; }
    
    /// <summary>
    /// 用户身份
    /// 0, 站长, 拥有所有权限
    /// 1, 顶级管理员, 拥有管理权限,可以管理编辑与用户
    /// 2-3待定
    /// 4, 编辑, 拥有推荐等权限,可以管理作者
    /// 5-6 待定
    /// 7, 作者
    /// 8, 读者
    /// </summary>
    public int Role { get; set; }

    /// <summary>
    /// 0, 正常状态
    /// 1, 禁止发言
    /// 2, 禁止登陆
    /// 3, 已经注销
    /// </summary>
    public ushort Status { get; set; }

    /// <summary>
    /// 等级,   范围 Lv0 - Lv10
    /// </summary>
    public ushort Level { get; set; }
    
    /// <summary>
    /// 是否是会员,赞助得会员
    /// </summary>
    public bool IsVip { get; set; }
    
    /// <summary>
    /// 自我描述,可为空
    /// </summary>
    public string? SelfIntroduction { get; set; } 
    

    /// <summary>
    /// 个性头衔列表,可以为空,标志用户所拥有的个性头衔
    /// 使用string存储,取出之后再序列化操作
    /// </summary>
    public string? TagList { get; set; } 

    /// <summary>
    /// 已经佩戴的个性头衔
    /// </summary>
    public Tag WearTag { get; set; } 

    /// <summary>
    /// 收藏夹, 被收藏的小说ID列表
    /// </summary>
    public string? Collections { get; set; } 

    /// <summary>
    /// 用户关注的作者id,使用string,取出来之后再解析
    /// </summary>
    public string? Follows { get; set; } 

    /// <summary>
    /// 关注该用户的所有用户id,允许用户关注自己
    /// </summary>
    public string? Followed { get; set; } 


    /// <summary>
    /// 虚拟货币彩色石头,赞助获得
    /// </summary>
    public int ColorStone { get; set; }

    /// <summary>
    /// 羽毛, 活动获得
    /// </summary>
    public int Feather { get; set; }
}