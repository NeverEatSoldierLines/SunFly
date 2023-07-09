using NovelRepositories.IRepositories;
using NovelRepositories.Repositories;
using NovelServices.IServices;

namespace NovelServices.Services;

public class EditorService : IEditorService
{
    public IEditorRepository EditorRepository { get;}

    public EditorService(IEditorRepository editorRepository)
    {
        EditorRepository = editorRepository;
    }
}