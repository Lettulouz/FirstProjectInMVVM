using System;

namespace Projekt_v0._04.Models;

public class Reservations
{
    public string ID { get; set; }
    public string Miasto { get; set; }
    public string Hotel { get; set; }
    public string Pokoj { get; set; }
    public string Uzytkownik { get; set; }
    public string DataPrzyjazdu { get; set; }
    public string DataWyjazdu { get; set; }
    public string RezerwacjaPotwierdzona { get; set; }
    public Reservations(string miasto, string hotel, string pokoj, string uzytkownik, DateTime dataPrzyjazdu, DateTime dataWyjazdu, bool rezerwacjaPotwierdzona, string id)
    {
        Miasto = miasto;
        Hotel = hotel;
        Pokoj = pokoj;
        Uzytkownik = uzytkownik;
        DataPrzyjazdu = dataPrzyjazdu.ToShortDateString();
        DataWyjazdu = dataWyjazdu.ToShortDateString();
        RezerwacjaPotwierdzona = rezerwacjaPotwierdzona.ToString();
        ID = id;
    }
}