using System.Data.Entity.Infrastructure.Design;
using System.Windows;

namespace Projekt_v0._04.Models;

public class AboutUs
{
    public string AboutUsMessage { get; }
    public double FontSizeDefine { get; }
    
    public string ImageLeftSource { get; }
    
    public  string ImageCenterSource { get; }
    
    public string  ImageRightSource { get; }

    public AboutUs()
    {
        AboutUsMessage = "Nasza sieć hoteli\n" +
                         "mieści się na terytorium \n" +
                         "całej Polski";
        FontSizeDefine = 36;
        ImageLeftSource = "/Resources/grupa_ludzi.jpg";
        ImageCenterSource = "/Resources/hotel.jpg";
        ImageRightSource = "/Resources/hotel2.jpg";
    }
}