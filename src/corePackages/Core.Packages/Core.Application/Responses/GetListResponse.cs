using Core.Persistence.Paging;

namespace Core.Application.Responses;

public class GetListResponse<T>:BasePageableModel
{
    private IList<T> _list;

    public IList<T> Items { get => _list??= new List<T>() ; set => _list = value; }
}
