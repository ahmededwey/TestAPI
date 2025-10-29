using CQRS_lib.DATA.Models;
using MediatR;

namespace CQRS_lib.CQRS.Handelers
{
    //public class InsertItemHandler : IRequestHandler<Commands.InsertItemCommand, Item>
    //{
    //    AppDbContext _Db;
    //    public InsertItemHandler(AppDbContext Db)
    //    {
    //        _Db = Db;
    //    }
    //    async Task<Item> IRequestHandler<Commands.InsertItemCommand, Item>.Handle(Commands.InsertItemCommand request, CancellationToken cancellationToken)
    //    {
    //        var res= _Db.Items.Add(request.item);
    //        await _Db.SaveChangesAsync();
    //        return await Task.FromResult(res.Entity);
    //    }
    //}
}
