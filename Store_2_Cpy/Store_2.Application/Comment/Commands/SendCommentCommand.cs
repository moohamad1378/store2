using MediatR;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store_2.Application.Comment.Commands
{
    public class SendCommentCommand:IRequest<SendCommentResponsDto>
    {
        public SendCommentCommand(CommentDto commentDto)
        {
            CommentDto = commentDto;
        }
        public CommentDto CommentDto { get; set; }
    }
    public class SendCommentHandler : IRequestHandler<SendCommentCommand, SendCommentResponsDto>
    {
        private readonly IDataBaseContext _context;
        public SendCommentHandler(IDataBaseContext context)
        {
            _context = context;
        }
        public Task<SendCommentResponsDto> Handle(SendCommentCommand request, CancellationToken cancellationToken)
        {
            var catalogitem = _context.CataLogItems.Find(request.CommentDto.cataLogItemId);
            CatalogItemComment comment = new CatalogItemComment()
            {
                Comment = request.CommentDto.Comment,
                Email = request.CommentDto.Email,
                Title = request.CommentDto.Title,
                cataLogItem = catalogitem
            };
            var entity = _context.CatalogItemComments.Add(comment);
            _context.SaveChanges();
            return Task.FromResult(new SendCommentResponsDto
            {
                Id = entity.Entity.Id
            });
        }
    }

    public class SendCommentResponsDto
    {
        public int Id { get; set; }
    }
    public class CommentDto
    {
        public string Title { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Comment { get; set; }
        public int cataLogItemId { get; set; }
    }
}
