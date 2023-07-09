using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NovelServices.IServices;

namespace NovelControllers.Controllers;


/// <summary>
/// 暂时只允许本地访问,等上线之后允许更多人访问编辑人员接口
/// </summary>
[EnableCors]
[Route("api/[controller]/[action]")]
[ApiController]
public class EditorController
{
    public IEditorService EditorService { get;}
    public ILogger<EditorController> Logger { get; set; }
    public EditorController(IEditorService editorService, ILogger<EditorController> logger)
    {
        Logger = logger;
        EditorService = editorService;
    }
}