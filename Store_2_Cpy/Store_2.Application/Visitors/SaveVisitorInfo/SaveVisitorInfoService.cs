using MongoDB.Driver;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Visitors;
using System;

namespace Store_2.Application.Visitors.SaveVisitorInfo
{
    //public class SaveVisitorInfoService : ISaveVisitorInfoService
    //{
    //    private readonly IMongoDBContext<Visitor> _mongoDBContext;
    //    private readonly IMongoCollection<Visitor> _visitormongoCollection;
    //    public SaveVisitorInfoService(IMongoDBContext<Visitor> mongoDBContext)
    //    {
    //        _mongoDBContext = mongoDBContext;
    //        _visitormongoCollection = _mongoDBContext.GetCollection();
    //    }
    //    public void Execute(RequestSaveVisitorInfoDto request)
    //    {
    //        _visitormongoCollection.InsertOne(new Visitor
    //        {
    //            Browser = new VisitorVersion
    //            {
    //                Family = request.Browser.Family,
    //                Version = request.Browser.Version,
    //            },
    //            CurrentLink = request.CurrentLink,
    //            Device = new Device
    //            {
    //                Brand = request.Device.Brand,
    //                Family = request.Device.Family,
    //                isSpider = request.Device.isSpider,
    //                Model = request.Device.Model
    //            },
    //            IP=request.IP,
    //            Method=request.Method,
    //            Operatonsystem=new VisitorVersion
    //            {
    //                Family=request.Operatonsystem.Family,
    //                Version=request.Operatonsystem.Version
    //            },
    //            PyhysicalPatch=request.PyhysicalPatch,
    //            Protocol=request.Protocol,
    //            ReferrerLink=request.ReferrerLink,
    //            VisitorId=request.VisitorId,
    //            Time=DateTime.Now
    //        });
    //    }
    //}
}
