using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Visitors
{
    public class Visitor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string IP { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PyhysicalPatch { get; set; }
        public VisitorVersion Browser { get; set; }
        public VisitorVersion Operatonsystem { get; set; }
        public Device Device { get; set; }
        [BsonDateTimeOptions(Kind =DateTimeKind.Local)]
        public DateTime Time { get; set; }
        public string VisitorId { get; set; }
    }
}
