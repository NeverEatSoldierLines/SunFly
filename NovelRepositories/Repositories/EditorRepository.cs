using NovelRepositories.Contexts;
using NovelRepositories.IRepositories;

namespace NovelRepositories.Repositories;

public class EditorRepository : IEditorRepository
{
    public EditorContext EditorContext { get; set; }

    public EditorRepository(EditorContext editorContext)
    {
        EditorContext = editorContext;
    }
    
    
}