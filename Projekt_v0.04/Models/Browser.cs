using System.Collections.Generic;
using System.Linq;
using static Projekt_v0._04.GlobalFunctions.AddToListStringClass;

namespace Projekt_v0._04.Models;

public class Browser
{
    public List<string> Cities = new List<string>();
    public string SelectedCity;
    public string BrowserContent, SearchForCity;
    public Browser()
    {
        
        SearchForCity = "Testy";
        BrowserContent = "Wpisz miasto, które Cię interesuje";
        AddToListString(Cities, "Gdańsk", "Gdynia", "Gniezno", "Warszawa", "Katowice", "Kraków", "Gliwice", 
            "Wieliczka", "Poznań", "Kołobrzeg", "Kielce", "Rzeszów", "Łódź", "Częstochowy", "Sosnowiec", "Bytom", 
            "Cieszyn", "Chorzów", "Zabrze");

        SelectedCity = "Warszawa";
    }

    public void CheckIfSelectedCityIsValid()
    {
        bool doItContain = Cities.Contains(SelectedCity);
        if (!doItContain)
        {
            SelectedCity = "Warszawa";
        }
    }
}