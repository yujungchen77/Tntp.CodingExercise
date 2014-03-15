using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace WebApplication2
{
    public class bios
    {
       //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        public IList<name> names { get; set; }

        public string title { get; set; }

        public DateTime birth { get; set; }

        public DateTime death { get; set; }

        public List<string> contribs { get; set; }

        public void AddContribs(string contrib)
        {
            if (contribs == null)
            {
                contribs = new List<string>();
            }
            contribs.Add(contrib);
        }

        public IList<awardlist> awards { get; set; }

    }
    public class name
    {
        public string first { get; set; }
        public string aka
        {
            get; set;
        }
        public string last { get; set; }
    }

    public class awardlist
    {
        public string award { get; set; }
        public int year { get; set; }
        public string by { get; set; }
    }
}