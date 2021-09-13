using MongoDB.Driver;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Visitors.GetTodayReport
{
    public interface IGetTodayReportService
    {
        ResultTodayReportDto Execute();
    }
    public class GetTodayReportService : IGetTodayReportService
    {
        private readonly IMongoDBContext<Visitor> _mongoDBContext;
        private readonly IMongoCollection<Visitor> visitormongoCollection;
        public GetTodayReportService(IMongoDBContext<Visitor> mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            visitormongoCollection = _mongoDBContext.GetCollection();
        }
        public ResultTodayReportDto Execute()
        {
            DateTime start = DateTime.Now.Date;
            DateTime end = DateTime.Now.AddDays(1);

            var TodayPageViewCount = visitormongoCollection.AsQueryable()
                .Where(p => p.Time >= start && p.Time < end).LongCount();

            var TodayVisitorCount = visitormongoCollection.AsQueryable()
                .Where(p => p.Time >= start && p.Time < end).GroupBy(p => p.VisitorId).LongCount();

            var AllPageViewCount = visitormongoCollection.AsQueryable().LongCount();
            var AllVisitorCount = visitormongoCollection.AsQueryable().GroupBy(p => p.VisitorId).LongCount();


            VisitCountDto visitperhour = NewMethod(start, end);

            VisitCountDto visitperday = NewMethod1();

            var Visitors = visitormongoCollection.AsQueryable()
                .OrderByDescending(p => p.Time).Take(10).Select(p => new VisitorsDto
                {
                    Id=p.Id,
                    Browser=p.Browser.Family,
                    CurrentLink=p.CurrentLink,
                    IP=p.IP,
                    OperationSystem=p.Operatonsystem.Family,
                    Isspider=p.Device.isSpider,
                    ReferrerLink=p.ReferrerLink,
                    Time=p.Time,
                    VisitorId=p.VisitorId
                }).ToList();

            return new ResultTodayReportDto
            {
                GeneralStateDto = new GeneralStateDto
                {
                    TotalVisitors = AllVisitorCount,
                    PageViewsPerVisitor = AllPageViewCount,
                    TotalPageView = AllPageViewCount / AllVisitorCount,
                    VisitPerDay = visitperday,
                },
                ToDay = new TodayDto
                {
                    PageViews = TodayPageViewCount,
                    Visitors = TodayVisitorCount,
                    ViewsPerVisitor = GetAvg(TodayPageViewCount, TodayVisitorCount),
                    VisitPerHour = visitperhour

                },
                visitors=Visitors
                
            };
        }

        private VisitCountDto NewMethod1()
        {
            DateTime MonthStart = DateTime.Now.Date.AddDays(-30);
            DateTime MonthENd = DateTime.Now.Date.AddDays(1);

            var Month_PageViewList = visitormongoCollection.AsQueryable()
                .Where(p => p.Time >= MonthStart && p.Time < MonthENd).Select(p => new { p.Time }).ToList();
            VisitCountDto visitperday = new VisitCountDto() { Display = new string[31], Value = new int[31] };
            for (int i = 0; i <= 30; i++)
            {
                var currentday = DateTime.Now.AddDays(i * (-1));
                visitperday.Display[i] = i.ToString();
                visitperday.Value[i] = Month_PageViewList.Where(p => p.Time.Date == currentday.Date).Count();

            }

            return visitperday;
        }

        private VisitCountDto NewMethod(DateTime start, DateTime end)
        {
            var TodayPagveViewList = visitormongoCollection.AsQueryable().Where(p => p.Time >= start && p.Time < end)
                .Select(p => new { p.Time }).ToList();
            VisitCountDto visitperhour = new VisitCountDto()
            {
                Display = new string[24],
                Value = new int[24]
            };
            for (int i = 0; i <= 23; i++)
            {
                visitperhour.Display[i] = $"H-{i}";
                visitperhour.Value[i] = TodayPagveViewList.Where(p => p.Time.Hour == i).Count();
            }

            return visitperhour;
        }

        private float GetAvg(long VisitPage,long Visitor)
        {
            if (Visitor == 0)
            {
                return 0;
            }
            else
            {
                return VisitPage / Visitor;
            }
        }
    }
    public class ResultTodayReportDto
    {

        public GeneralStateDto GeneralStateDto { get; set; }
        public  TodayDto ToDay { get; set; }
        public List<VisitorsDto> visitors { get; set; }
    }
    public class GeneralStateDto
    {
        public long TotalPageView { get; set; }
        public long TotalVisitors { get; set; }
        public float PageViewsPerVisitor { get; set; }
        public VisitCountDto VisitPerDay { get; set; }
    }
    public class TodayDto
    {
        public long PageViews { get; set; }
        public long Visitors { get; set; }
        public float ViewsPerVisitor { get; set; }
        public VisitCountDto VisitPerHour { get; set; }
    }
    public class VisitCountDto
    {
        public string[] Display { get; set; }
        public int[] Value { get; set; }
    }
    public class VisitorsDto
    {
        public string Id { get; set; }
        public string IP { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public string Browser { get; set; }
        public string OperationSystem { get; set; }
        public bool Isspider { get; set; }
        public DateTime Time { get; set; }
        public string VisitorId { get; set; }
    }
}
