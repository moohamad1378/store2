using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store_2.Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Store_2.Application.Catalogs.CatalogItems.GetGatalogItemPDP;
using Store_2.Application.Comment.Commands;
using Store_2.Application.Comment.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPService _pLPService;
        private readonly IGetCatalogItemPDPService _getCatalogItemPDPService;
        private readonly IMediator mediator;

        public ProductController(IGetCatalogItemPLPService pLPService,
            IGetCatalogItemPDPService getCatalogItemPDPService,IMediator mediator)
        {
            _pLPService = pLPService;
            _getCatalogItemPDPService = getCatalogItemPDPService;
            this.mediator = mediator;
        }
        public IActionResult Index(CatalogPLPRequestDto requestDto)
        {
            var data = _pLPService.Execute(requestDto);


            return View(data);
        }
        public IActionResult Details(int Id)
        {
            var data = _getCatalogItemPDPService.Execute(Id);
            GetCommentOfCatalogItemRequest itemdto = new GetCommentOfCatalogItemRequest()
            {
                Catalogitemid = data.Id
            };
            var result = mediator.Send(itemdto).Result;
            return View(data);
        }
        public IActionResult SendComment(CommentDto commentDto,string slug)
        {
            SendCommentCommand sendComment = new SendCommentCommand(commentDto);
            var result= mediator.Send(sendComment).Result;
            return RedirectToAction(nameof(Details));
        }
    }
}
