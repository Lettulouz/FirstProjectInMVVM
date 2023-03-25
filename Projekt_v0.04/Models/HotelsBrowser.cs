using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySqlConnector;


namespace Projekt_v0._04.Models;

public class HotelsBrowser
{
    string myConnectionString=
        "stąd zostały usunięte dane do logowania do bazy danych";
    private MySqlConnection connection;
    public string SelectedCity;
    public string Zdjecie1, Zdjecie2, Zdjecie3;
    public string NazwaHotelu1, WolnePokoje1, WszystkiePokoje1, NazwaHotelu2, WolnePokoje2, WszystkiePokoje2, 
        NazwaHotelu3, WolnePokoje3, WszystkiePokoje3, Atrybut122, Atrybut123, Atrybut124, Atrybut125, Atrybut222, 
        Atrybut223, Atrybut224, Atrybut225, Atrybut322, Atrybut323, Atrybut324, Atrybut325;

    public double Wyszukanie1Przejrzystosc =  1, Wyszukanie2Przejrzystosc = 1, Wyszukanie3Przejrzystosc = 1;
    public bool IsEnabled1, IsEnabled2, IsEnabled3;
    public string ConvSelectedCity;
    public HotelsBrowser()
    {
    }

    public void LoadHotelsProperties()
    {
        IsEnabled1 = false;
        IsEnabled2 = false;
        IsEnabled3 = false;
        Wyszukanie1Przejrzystosc = .0;
        Wyszukanie2Przejrzystosc = .0;
        Wyszukanie3Przejrzystosc = .0;
        ConvSelectedCity = "'" + SelectedCity + "'";
        connection = new MySqlConnection(myConnectionString);
        MySqlCommand select = new MySqlCommand($"SELECT * FROM allhotels where Miasto={ConvSelectedCity}", connection);
        connection.Open();
        MySqlDataAdapter adapter = new MySqlDataAdapter(select);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        MySqlDataReader reader = select.ExecuteReader();
        int numberOfLoop = 0;
        while (reader.Read())
        {
            if (numberOfLoop == 0)
            {
                Wyszukanie1Przejrzystosc = 1.0;
                IsEnabled1 = true;
                NazwaHotelu1 = reader["NazwaHotelu"].ToString();
                Zdjecie1 = reader["ImagePath"].ToString();
                Atrybut122 = reader["Atrybut2"].ToString();
                Atrybut123 = reader["Atrybut3"].ToString();
                Atrybut124 = reader["Atrybut4"].ToString();
                Atrybut125 = reader["Atrybut5"].ToString();
                WolnePokoje1 = reader["LiczbaWolnychPokoi"].ToString();
                WszystkiePokoje1 = reader["LiczbaWszystkichPokoi"].ToString();
                numberOfLoop++;
            }
            else if (numberOfLoop == 1)
            {
                Wyszukanie2Przejrzystosc = 1;
                IsEnabled2 = true;
                NazwaHotelu2 = reader["NazwaHotelu"].ToString();
                Zdjecie2 = reader["ImagePath"].ToString();
                Atrybut222 = reader["Atrybut2"].ToString();
                Atrybut223 = reader["Atrybut3"].ToString();
                Atrybut224 = reader["Atrybut4"].ToString();
                Atrybut225 = reader["Atrybut5"].ToString();
                WolnePokoje2 = reader["LiczbaWolnychPokoi"].ToString();
                WszystkiePokoje2 = reader["LiczbaWszystkichPokoi"].ToString();
                numberOfLoop++;
            }
            else if (numberOfLoop == 2)
            {
                Wyszukanie3Przejrzystosc = 3;
                IsEnabled3 = true;
                NazwaHotelu3 = reader["NazwaHotelu"].ToString();
                Zdjecie3 = reader["ImagePath"].ToString();
                Atrybut322 = reader["Atrybut2"].ToString();
                Atrybut323 = reader["Atrybut3"].ToString();
                Atrybut324 = reader["Atrybut4"].ToString();
                Atrybut325 = reader["Atrybut5"].ToString();
                WolnePokoje3 = reader["LiczbaWolnychPokoi"].ToString();
                WszystkiePokoje3 = reader["LiczbaWszystkichPokoi"].ToString();
                numberOfLoop = 0;
            }
        }
    }
}