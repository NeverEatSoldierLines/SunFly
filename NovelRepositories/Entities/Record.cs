using System.ComponentModel.DataAnnotations;
using NovelRepositories.DataInMemory;

namespace NovelRepositories.Entities;

/// <summary>
/// 管理员操作记录
/// </summary>
public class AdminOperateRecord
{
    [Key]
    public int RecordId { get; set; }
    
    public AdminOperateType OperatorType { get; set; }

    
    // /// <summary>//在service层做这个
    // /// 操作描述
    // /// </summary>
    // public string? Detail => Enum.GetName(OperatorType);

    public DateTime OperateTime { get; set; } = DateTime.Now;
    
    public int AdminTime { get; set; }
}

/// <summary>
/// 编辑操作记录
/// </summary>
public class EditorOperateRecord
{
    [Key]
    public int RecordId { get; set; }

    
    public EditorOperatorType OperatorType { get; set; }

    // /// <summary>//在控制层做这个
    // /// 操作描述
    // /// </summary>
    // public string? Detail => Enum.GetName(OperatorType);
    
    public DateTime OperateTime { get; set; }
    
    /// <summary>
    /// 是否已辞职
    /// </summary>
    public bool IsResigned { get; set; }
}