using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Wrappers;
using MongoDB.Bson.Serialization;


namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private MongoDbDao _mongoDbDao;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //MongoDB name="local"
            _mongoDbDao = new MongoDbDao("local");
            //Collection name ="bios"
            _mongoDbDao.UseCollection("bios");

            //1
            var bios = new bios()
            {
                names = new List<name> { { new name() { first = "John", last = "Backus" } } },
                birth = DateTime.Parse("1924-12-03T05:00:00Z"),
                death = DateTime.Parse("2007-03-17T04:00:00Z"),
                awards = new List<awardlist> 
                { 
                     { new awardlist() { award = "W.W. McDowell Award", year = 1967, by ="IEEE Computer Society" } } ,
                     { new awardlist() { award = "National Medal of Science", year = 1975, by ="National Science Foundation" } } ,
                     { new awardlist() { award = "Turing Award", year = 1977, by ="ACM" } } ,
                     { new awardlist() { award = "Draper Prize", year = 1993, by ="National Academy of Engineering" } }
                }

            };
            bios.AddContribs("Fortran");
            bios.AddContribs("ALGOL");
            bios.AddContribs("Backus-Naur Form");
            bios.AddContribs("FP");

            _mongoDbDao.Insert<bios>(bios);


            //2
            bios = new bios()
            {
                names = new List<name> { { new name() { first = "John", last = "McCarthy" } } },
                birth = DateTime.Parse("1927-09-04T04:00:00Z"),
                death = DateTime.Parse("2011-12-24T05:00:00Z"),
                awards = new List<awardlist> 
                { 
                     { new awardlist() { award = "Turing Award", year = 1971, by ="ACM" } } ,
                     { new awardlist() { award = "Kyoto Prize", year = 1988, by ="Inamori Foundation" } } ,
                     { new awardlist() { award = "National Medal of Science", year = 1990, by ="National Science Foundation" } }
                }

            };
            bios.AddContribs("Lisp");
            bios.AddContribs("Artificial Intelligence");
            bios.AddContribs("ALGOL");

            _mongoDbDao.Insert<bios>(bios);

            //3
            bios = new bios()
            {
                names = new List<name> { { new name() { first = "Grace", last = "Hopper" } } },
                title = "Rear Admiral",
                birth = DateTime.Parse("1906-12-09T05:00:00Z"),
                death = DateTime.Parse("1992-01-01T05:00:00Z"),
                awards = new List<awardlist> 
                { 
                     { new awardlist() { award = "Computer Sciences Man of the Year", year = 1969, by ="Data Processing Management Association" } } ,
                     { new awardlist() { award = "Distinguished Fellow", year = 1973, by ="British Computer Society" } } ,
                     { new awardlist() { award = "W. W. McDowell Award", year = 1976, by ="IEEE Computer Society" } },
                     { new awardlist() { award = "National Medal of Technology", year = 1991, by ="United States" } }
                }
            };
            bios.AddContribs("UNIVAC");
            bios.AddContribs("compiler");
            bios.AddContribs("FLOW-MATIC");
            bios.AddContribs("COBOL");

            _mongoDbDao.Insert<bios>(bios);

            //4
            bios = new bios()
            {
                names = new List<name> { { new name() { first = "Kristen", last = "Nygaard" } } },
                birth = DateTime.Parse("1926-08-27T04:00:00Z"),
                death = DateTime.Parse("2002-08-10T04:00:00Z"),
                awards = new List<awardlist> 
                { 
                     { new awardlist() { award = "Rosing Prize", year = 1999, by ="Norwegian Data Association" } } ,
                     { new awardlist() { award = "Turing Award", year = 2001, by ="ACM" } } ,
                     { new awardlist() { award = "IEEE John von Neumann Medal", year = 2001, by ="IEEE" } }
                }

            };
            bios.AddContribs("OOP");
            bios.AddContribs("Simula");

            _mongoDbDao.Insert<bios>(bios);

            //5
            bios = new bios()
            {
                names = new List<name> { { new name() { first = "Ole-Johan", last = "Dahl" } } },
                birth = DateTime.Parse("1931-10-12T04:00:00Z"),
                death = DateTime.Parse("2002-06-29T04:00:00Z"),
                awards = new List<awardlist> 
                { 
                     { new awardlist() { award = "Rosing Prize", year = 1999, by ="Norwegian Data Association" } } ,
                     { new awardlist() { award = "Turing Award", year = 2001, by ="ACM" } } ,
                     { new awardlist() { award = "IEEE John von Neumann Medal", year = 2001, by ="IEEE" } }
                }

            };
            bios.AddContribs("OOP");
            bios.AddContribs("Simula");

            _mongoDbDao.Insert<bios>(bios);

            //6
            bios = new bios()
            {
                names = new List<name> { { new name() { first = "Guido", last = "van Rossum" } } },
                birth = DateTime.Parse("1956-01-31T05:00:00Z"),
                awards = new List<awardlist> 
                { 
                     { new awardlist() { award = "Award for the Advancement of Free Software", year = 2001, by ="Free Software Foundation" } } ,
                     { new awardlist() { award = "NLUUG Award", year = 2003, by ="NLUUG" } } 
                }

            };
            bios.AddContribs("Python");

            _mongoDbDao.Insert<bios>(bios);

            //7
            bios = new bios()
            {
                names = new List<name> { { new name() { first = "Dennis", last = "Ritchie" } } },
                birth = DateTime.Parse("1941-09-09T04:00:00Z"),
                death = DateTime.Parse("2011-10-12T04:00:00Z"),
                awards = new List<awardlist> 
                { 
                     { new awardlist() { award = "Turing Award", year = 1983, by ="ACM" } } ,
                     { new awardlist() { award = "National Medal of Technology", year = 1998, by ="United States" } } ,
                     { new awardlist() { award = "Japan Prize", year = 2011, by ="The Japan Prize Foundation" } }
                }

            };
            bios.AddContribs("UNIX");
            bios.AddContribs("C");

            _mongoDbDao.Insert<bios>(bios);

            //8
            bios = new bios()
            {
                names = new List<name> { { new name() { first = "Yukihiro", aka = "Matz", last = "Matsumoto" } } },
                birth = DateTime.Parse("1965-04-14T04:00:00Z"),
                awards = new List<awardlist> 
                { 
                     { new awardlist() { award = "Award for the Advancement of Free Software", year = 2011, by ="Free Software Foundation" } }
                }

            };
            bios.AddContribs("Ruby");

            _mongoDbDao.Insert<bios>(bios);

            //9
            bios = new bios()
            {
                names = new List<name> { { new name() { first = "James", last = "Gosling" } } },
                birth = DateTime.Parse("1955-05-19T04:00:00Z"),
                awards = new List<awardlist> 
                { 
                     { new awardlist() { award = "The Economist Innovation Award", year = 2002, by ="The Economist" } } ,
                     { new awardlist() { award = "Officer of the Order of Canada", year = 2007, by ="Canada" } }
                }

            };
            bios.AddContribs("Java");

            _mongoDbDao.Insert<bios>(bios);

            //10
            bios = new bios()
            {
                names = new List<name> { { new name() { first = "Martin", last = "Odersky" } } },
            };
            bios.AddContribs("Scala");

            _mongoDbDao.Insert<bios>(bios);

            lblMessage.Visible = true;
            lblMessage.Text = "Insert Data to MongoDB Complete!";
            btnInsert.Enabled = false;
        }
        protected void btnConvert_Click(object sender, EventArgs e)
        {
            string _id, firstname, lastname, aka, title, award, by;
            DateTime birth, death;
            int year;
            SqlCommand cmd;

            _mongoDbDao = new MongoDbDao("local");
            _mongoDbDao.UseCollection("bios");

            //SQL server connectstring
            string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(strConn);
            conn.Open();

            lblMessage.Visible = true;
            foreach (var doc in _mongoDbDao.GetAll<bios>())
            {
                firstname = "";
                lastname = "";
                aka = "";
                _id = (doc._id.ToJson().ToString()) == "null" ? "" : doc._id.ToString();
                
                //Get name data
                foreach (var na in doc.names)
                {
                    firstname = (na.first.ToJson().ToString()) == "null" ? "" : na.first.ToString();
                    lastname = (na.last.ToJson().ToString()) == "null" ? "" : na.last.ToString();
                    aka = (na.aka.ToJson().ToString())=="null" ? "" : na.aka.ToString() ;
                }
                title = (doc.title.ToJson().ToString()) == "null" ? "" : doc.title.ToString();
                birth = (doc.birth.ToString()) == "1/1/0001 12:00:00 AM" ? Convert.ToDateTime("1/1/1900 00:00:00AM") : Convert.ToDateTime(doc.birth.ToString());
                death = (doc.death.ToString()) == "1/1/0001 12:00:00 AM" ? Convert.ToDateTime("1/1/1900 00:00:00AM") : Convert.ToDateTime(doc.death.ToString());

                //Insert root document
                cmd = new SqlCommand("usp_InsertDevelopers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@_id", _id));
                cmd.Parameters.Add(new SqlParameter("@birth", birth));
                cmd.Parameters.Add(new SqlParameter("@death", death));
                cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
                cmd.Parameters.Add(new SqlParameter("@lastname", lastname));
                cmd.Parameters.Add(new SqlParameter("@aka", aka));
                cmd.Parameters.Add(new SqlParameter("@title", title));
                cmd.ExecuteNonQuery();

                if (doc.contribs.Count > 0)
                {
                    //Insert contribs data
                    for (int i = 0; i < doc.contribs.Count; i++)
                    {
                        cmd = new SqlCommand("usp_InsertContribs", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@_id", _id));
                        cmd.Parameters.Add(new SqlParameter("@birth", birth));
                        cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
                        cmd.Parameters.Add(new SqlParameter("@lastname", lastname));
                        cmd.Parameters.Add(new SqlParameter("@contrib", doc.contribs[i].ToString()));
                        cmd.ExecuteNonQuery();

                    }
                }

                if (doc.awards.ToJson().ToString()!="null")
                {
                    //Insert award data
                    foreach (var aw in doc.awards)
                    {
                        award = (aw.award.ToJson().ToString()) == "null" ? "" : aw.award.ToString();
                        year = (aw.year.ToJson().ToString()) == "null" ? 0 : aw.year;
                        by = (aw.by.ToJson().ToString()) == "null" ? "" : aw.by.ToString();

                        cmd = new SqlCommand("usp_InsertAwards", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@_id", _id));
                        cmd.Parameters.Add(new SqlParameter("@birth", birth));
                        cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
                        cmd.Parameters.Add(new SqlParameter("@lastname", lastname));
                        cmd.Parameters.Add(new SqlParameter("@award", award));
                        cmd.Parameters.Add(new SqlParameter("@year", year));
                        cmd.Parameters.Add(new SqlParameter("@by", by));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            conn.Close();
            lblMessage.Text = "Successfully convert data to SQL server!";

        }

    }
}