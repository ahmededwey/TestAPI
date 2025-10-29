using CQRS_lib.CQRS.Queries;
using CQRS_lib.DATA.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.CQRS.Handelers
{
    //public class GetItemsListHandler : IRequestHandler<GetAllItems, List<Item>>
    //{
    //    AppDbContext _Db;
    //    public GetItemsListHandler(AppDbContext Db)
    //    {
    //        _Db = Db;
    //    }
    //    async Task<List<Item>> IRequestHandler<GetAllItems, List<Item>>.Handle(GetAllItems request, CancellationToken cancellationToken)
    //    {
    //        return await Task.FromResult(_Db.Items.ToList());  
    //    }
    //}
}
