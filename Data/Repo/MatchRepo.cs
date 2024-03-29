﻿using BlazerServerCoaching.Data.Models;
using Microsoft.Data.SqlClient;

namespace BlazerServerCoaching.Data.Repo
{
    public class MatchRepo : Repository
    {
        private static List<Match> matches = new();

        public override void Load()
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT Id, Date, Type, Oppenent, Maps, Status, TsideW, TSideL, CTSideW, CTSideL, TPistol, CTPistol FROM MATCHS", con);

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
						DateTime date = Convert.ToDateTime(reader["Date"]);

						string TypeString = reader["Type"].ToString();
                        Models.MatchType type =0;
                        if (!string.IsNullOrEmpty(TypeString))
                        {
                            type = Enum.Parse<Models.MatchType>(TypeString);
                        }

                        string Oppenent = reader["Oppenent"].ToString();

                        string Maps = reader["Maps"].ToString();
                        Models.MatchMaps map=0;
                        if (!string.IsNullOrEmpty(Maps))
                        {
                            map = Enum.Parse<Models.MatchMaps>(Maps);
                        }

                        string Status = reader["status"].ToString();
                        Models.MatchStatus status = 0;
                        if (!string.IsNullOrEmpty(Status))
                        {
                            status = Enum.Parse<Models.MatchStatus>(Status);
                        }

                        int TsideW = Convert.ToInt32(reader["TsideW"]);
                        int TsideL = Convert.ToInt32(reader["TsideL"]);
                        int CTsideW = Convert.ToInt32(reader["CTsideW"]);
                        int CTsideL = Convert.ToInt32(reader["CTsideL"]);
                        bool TPistol = Convert.ToBoolean(reader["TPistol"]);
                        bool CTPistol = Convert.ToBoolean(reader["CTPistol"]);

                        Match match = new(id, date, type, Oppenent, map, status, TsideW, TsideL, CTsideW, CTsideL, TPistol, CTPistol);

                        matches.Add(match);                                                                                                                                         
                    }
                }
            }
        }

        public void Save(DateTime? date, Models.MatchType type, string oppenent, MatchMaps maps, MatchStatus status, int tSideW, int tSideL, int cTSideW, int cTSideL, bool tPistol, bool cTPistol)
        {
            using (SqlConnection con  = GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO MATCHS (Date, Type, Oppenent, Maps, Status, TsideW, TSideL, CTSideW, CTSideL, TPistol, CTPistol) " + "VALUES(@Date, @Type, @Oppenent, @Maps, @Status, @TsideW, @TsideL, @CTSideW, @CTSideL, @TPistol, @CTPistol)", con);

                //cmd.Parameters.AddWithValue("@Id", id.ToString());
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Type", type.ToString());
                cmd.Parameters.AddWithValue("@Oppenent", oppenent.ToString());
                cmd.Parameters.AddWithValue("@Maps", maps.ToString());
                cmd.Parameters.AddWithValue("@Status", status.ToString());
                cmd.Parameters.AddWithValue("@TsideW", tSideW.ToString());
                cmd.Parameters.AddWithValue("@TsideL", tSideL.ToString());
                cmd.Parameters.AddWithValue("@CTsideW", cTSideW.ToString());
                cmd.Parameters.AddWithValue("@CTsideL", cTSideL.ToString());
                cmd.Parameters.AddWithValue("@TPistol", tPistol.ToString());
                cmd.Parameters.AddWithValue("@CTPistol", cTPistol.ToString());

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"DELETE FROM MATCHS WHERE Id = {id} ", con);

                cmd.ExecuteNonQuery();

            }
        }


        public Match Retrieve(string id)
        {
            foreach (Match match in matches)
                if (id == match.Id.ToString())
                    return match;

            throw new ArgumentException($"Could not find employee with mail: {id}");
        }

        public static List<Match> GetMatchList()
        {
            return matches;
        }
    }
}
