using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace IEEEBACKEND.Services
{
    public class SQL
    {
        private static string Host = "127.0.0.1";
        private static string User = "*****************";
        private static string DBname = "*****************";
        private static string Password = "*****************";
        private static string Port = "5432";

        private string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
        public Models.Header[] GetHeaders()
        {
            List<Models.Header> Headers = new List<Models.Header>();
            using (var conn = new NpgsqlConnection(connString))
            {

                conn.Open();
                using (var comm = new NpgsqlCommand("SELECT \"Photo\", Head.\"Title\", \"Content\" FROM public.\"Header\" Head LEFT JOIN public.\"Thing\" Thi ON Head.\"Ref\" = Thi.\"ID\" ORDER BY Head.\"ID\" DESC FETCH FIRST 3 ROWS ONLY", conn))
                {
                    var reader = comm.ExecuteReader();

                    while (reader.Read())
                        Headers.Add(new Models.Header(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));

                    reader.Close();
                }
            }
            return Headers.ToArray();
        }

        public Models.Thing[] GetHomepageNews()
        {
            List<Models.Thing> Headers = new List<Models.Thing>();
            using (var conn = new NpgsqlConnection(connString))
            {

                conn.Open();
                using (var comm = new NpgsqlCommand("SELECT(SELECT \"Name\" FROM public.\"Committee\" co WHERE \"Committee\" = co.\"ID\") AS CommitteeName, \"Title\", \"HeaderPhoto\", \"Description\", \"Content\", \"DateAdded\" FROM public.\"Thing\" WHERE \"DateAdded\" IN (SELECT MAX(\"DateAdded\") FROM public.\"Thing\" GROUP BY \"Committee\") ORDER BY \"DateAdded\" DESC;", conn))
                {
                    var reader = comm.ExecuteReader();

                    while (reader.Read())
                        Headers.Add(new Models.Thing(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4), reader.GetTimeStamp(5).ToString() ));

                    reader.Close();
                }
            }
            return Headers.ToArray();
            
        }

        public Models.Thing[] GetLatestNews(int Offset)
        {
            List<Models.Thing> Headers = new List<Models.Thing>();
            using (var conn = new NpgsqlConnection(connString))
            {

                conn.Open();
                using (var comm = new NpgsqlCommand("SELECT(SELECT \"Name\" FROM public.\"Committee\" co WHERE \"Committee\" = co.\"ID\") AS CommitteeName, \"Title\", \"HeaderPhoto\", \"Description\", \"Content\", \"DateAdded\" FROM public.\"Thing\" ORDER BY \"DateAdded\" DESC OFFSET "+ Offset +" FETCH FIRST 10 ROW ONLY ", conn))
                {
                    var reader = comm.ExecuteReader();

                    while (reader.Read())
                        Headers.Add(new Models.Thing(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4), reader.GetTimeStamp(5).ToString()));

                    reader.Close();
                }
            }
            return Headers.ToArray();

        }

        public Models.Thing[] GetLatestNewsOfCommittee(string ShortCommitteeName,int Offset)
        {
            List<Models.Thing> Headers = new List<Models.Thing>();
            using (var conn = new NpgsqlConnection(connString))
            {

                conn.Open();
                using (var comm = new NpgsqlCommand("SELECT(SELECT \"Name\" FROM public.\"Committee\" co WHERE \"Committee\" = co.\"ID\") AS CommitteeName, \"Title\", \"HeaderPhoto\", \"Description\", \"Content\", \"DateAdded\" FROM public.\"Thing\" WHERE \"Committee\" = (SELECT \"ID\" FROM public.\"Committee\" WHERE \"Short\" = '"+ ShortCommitteeName + "') ORDER BY \"DateAdded\" DESC OFFSET "+Offset+" FETCH FIRST 10 ROW ONLY ", conn))
                {
                    var reader = comm.ExecuteReader();

                    while (reader.Read())
                        Headers.Add(new Models.Thing(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4), reader.GetTimeStamp(5).ToString()));

                    reader.Close();
                }
            }
            return Headers.ToArray();

        }

        public string GetContent(int id)
        {
            string path = "";
            using (var conn = new NpgsqlConnection(connString))
            {

                conn.Open();
                using (var comm = new NpgsqlCommand("SELECT \"Path\" FROM public.\"Content\" WHERE \"ID\" = " + id, conn))
                {
                    var reader = comm.ExecuteReader();

                    while (reader.Read())
                        path += reader.GetString(0);

                    reader.Close();
                }
            }
            return path;
        }

    }
}
