using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Store_2.Application.Visitors.SaveVisitorInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace Store_3.EndPoint.Utilities.Filters
{
    //public class SaveVisitorFilter : IActionFilter
    //{
    //    private readonly ISaveVisitorInfoService _saveVisitorInfoService;
    //    public SaveVisitorFilter(ISaveVisitorInfoService saveVisitorInfoService)
    //    {
    //        _saveVisitorInfoService = saveVisitorInfoService;
    //    }

    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {
            
    //    }

    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        string ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
    //        var actionname = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
    //        var controllername= ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
    //        var useragent = context.HttpContext.Request.Headers["User-Agent"];
    //        var uaparser = Parser.GetDefault();
    //        ClientInfo clientInfo= uaparser.Parse(useragent);
    //        var referer = context.HttpContext.Request.Headers["Referer"].ToString();
    //        var currentUrl = context.HttpContext.Request.Path;
    //        var request = context.HttpContext.Request;
    //        string visitorid = context.HttpContext.Request.Cookies["VisitorId"];
    //        if(visitorid == null)
    //        {
    //            visitorid = Guid.NewGuid().ToString();
    //            context.HttpContext.Response.Cookies.Append("VisitorId", visitorid,new CookieOptions 
    //            {
    //                Path="/",
    //                HttpOnly=true,
    //                Expires=DateTime.Now.AddDays(60)
    //            });
    //        }

    //        _saveVisitorInfoService.Execute(new RequestSaveVisitorInfoDto 
    //        {
    //            Browser=new VisitorVersionDto
    //            {
    //                Family=clientInfo.UA.Family,
    //                Version=$"{clientInfo.UA.Major}.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}"
    //            },
    //            CurrentLink=currentUrl,
    //            Device=new DeviceDto
    //            {
    //                Brand=clientInfo.Device.Brand,
    //                Family=clientInfo.Device.Family,
    //                isSpider=clientInfo.Device.IsSpider,
    //                Model=clientInfo.Device.Model
    //            },
    //            IP=ip,
    //            Method=request.Method,
    //            Operatonsystem=new VisitorVersionDto
    //            {
    //                Family=clientInfo.OS.Family,
    //                Version = $"{clientInfo.UA.Major}.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}"
    //            },
    //            PyhysicalPatch=$"{controllername}/{actionname}",
    //            Protocol=request.Protocol,
    //            ReferrerLink=referer,
    //            VisitorId=visitorid
    //        });
    //    }
    //}
}
