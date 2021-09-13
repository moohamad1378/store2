using MediatR;
using Store_2.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store_2.Application.Comment.Queries
{
    public class GetCommentOfCatalogItemRequest:IRequest<List<GetCommentDto>>
    {
        public int Catalogitemid { get; set; }
    }
    public class GetCommentOfcatalogItemQuery : IRequestHandler<GetCommentOfCatalogItemRequest, List<GetCommentDto>>
    {
        private readonly IDataBaseContext context;

        public GetCommentOfcatalogItemQuery(IDataBaseContext context)
        {
            this.context = context;
        }
        public Task<List<GetCommentDto>> Handle(GetCommentOfCatalogItemRequest request, CancellationToken cancellationToken)
        {
            var comments = context.CatalogItemComments
                .Where(p => p.cataLogItemId == request.Catalogitemid)
                .Select(p => new GetCommentDto
                {
                    Comment = p.Comment,
                    Id = p.Id,
                    Title = p.Title
                }).ToList();
            return Task.FromResult(comments);
        }
    }
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Comment { get; set; }
        public int cataLogItemId { get; set; }
    }
}
