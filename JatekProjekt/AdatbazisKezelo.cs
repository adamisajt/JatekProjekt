using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{
    public class AdatbazisKezelo
    {
        private readonly string connectionString;

        public AdatbazisKezelo()
        {
            connectionString =
                "Server=localhost;Database=JatekDb;Uid=root;Pwd=;Charset=utf8mb4;";
        }

        public List<Karakter> AdatokBetoltese()
        {
            List<Karakter> karakterek = new List<Karakter>();

            using (MySqlConnection kapcsolat = new MySqlConnection(connectionString))
            {
                kapcsolat.Open();

                string sql = "SELECT * FROM Karakterek ORDER BY Id";

                using (MySqlCommand parancs = new MySqlCommand(sql, kapcsolat))
                {
                    using (MySqlDataReader olvaso = parancs.ExecuteReader())
                    {
                        while (olvaso.Read())
                        {
                            Karakter karakter = new Karakter(
                                olvaso.GetInt32("Id"),
                                olvaso.GetString("Nev"),
                                olvaso.GetString("Osztaly"),
                                olvaso.GetInt32("Szint"),
                                olvaso.GetInt32("Arany"),
                                olvaso.GetString("Szerver")
                            );

                            karakterek.Add(karakter);
                        }
                    }
                }
            }

            return karakterek;
        }
    }
}
