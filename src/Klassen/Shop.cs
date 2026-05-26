using Quiz_show.src.Klassen;
using System;
using System.Collections.Generic;
using System.Windows.Media;

using System.Windows.Media;
public static class Shop
{
    public static double Money = 200;

    public static event Action ShopUpdated;
    public static List<ShopItems> Freigeschaltet = new();


    public static ShopItems AktiverButton =
        ShopItems.OriginalButton;

    public static ShopItems AktiverBackground =
        ShopItems.OriginalBackground;

    // Kaufen
    public static void Purchase(ShopItems item)
    {

        if (Freigeschaltet.Contains(item))
        {
            Select(item);
            return;
        }

        int preis = GetPrice(item);

        if (Money >= preis)
        {
            Money -= preis;

            Freigeschaltet.Add(item);

            Select(item);

            Console.WriteLine(item + " gekauft!");
        }
        else
        {
            Console.WriteLine("Nicht genug Geld!");
        }

        ShopUpdated?.Invoke();
    }

    // Auswählen
    public static void Select(ShopItems item)
    {
        switch (item)
        {
            case ShopItems.OriginalButton:
            case ShopItems.RotButton:
            case ShopItems.GoldButton:

                AktiverButton = item;
                break;

            case ShopItems.OriginalBackground:
            case ShopItems.GrünBackground:
            case ShopItems.SilberBackground:

                AktiverBackground = item;
                break;
        }

        ShopUpdated?.Invoke();

        Console.WriteLine(item + " ausgewählt!");
    }

    // Preis
    public static int GetPrice(ShopItems item)
    {
        switch (item)
        {
            case ShopItems.RotButton:
                return 20;

            case ShopItems.GoldButton:
                return 100;

            case ShopItems.GrünBackground:
                return 30;

            case ShopItems.SilberBackground:
                return 100;

            default:
                return 0;
        }
    }

    // Button
    public static Color GetButtonColor()
    {
        switch (AktiverButton)
        {
            case ShopItems.RotButton:
                return Colors.Red;

            case ShopItems.GoldButton:
                return Colors.Gold;

            default:
                return Colors.SkyBlue;
        }
    }

    // Background
    public static Color GetBackgroundColor()
    {
        switch (AktiverBackground)
        {
            case ShopItems.GrünBackground:
                return Colors.Green;

            case ShopItems.SilberBackground:
                return Colors.Silver;

            default:
                return Colors.White;
        }
    }
}