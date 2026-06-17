using Quiz_show.Frames;
using Quiz_show.src.Klassen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;

// KI: ChatGPT 
// Prompt: Wie kann ich Shop-Daten in JSON speichern und laden ohne eine separate Klasse zu verwenden? 
// Anfang KI:
public class ShopSaveData
{
    public double Money { get; set; }
    public List<ShopItems> Freigeschaltet { get; set; }
    public ShopItems AktiverButton { get; set; }
    public ShopItems AktiverBackground { get; set; }
}
// Ende KI:

public static class Shop
{
    public static double Money = 0;

    public static event Action ShopUpdated;

    public static List<ShopItems> Freigeschaltet = new List<ShopItems>();

    public static ShopItems AktiverButton = ShopItems.OriginalButton;
    public static ShopItems AktiverBackground = ShopItems.OriginalBackground;

    public static void Purchase(ShopItems item)
    {
        if (Freigeschaltet.Contains(item))
        {
            Select(item);
            Save();
            ShopUpdated?.Invoke();
            return;
        }

        int preis = GetPrice(item);

        if (Money >= preis)
        {
            Money -= preis;
            Freigeschaltet.Add(item);

            Select(item);

            
            Save();
        }


        ShopUpdated?.Invoke();
    }


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

    }

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


    public static void Save()
    {
        ShopSaveData daten = new ShopSaveData
        {
            Money = Money,
            Freigeschaltet = Freigeschaltet,
            AktiverButton = AktiverButton,
            AktiverBackground = AktiverBackground
        };

        string json = JsonSerializer.Serialize(daten, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("shop.json", json);

        Console.WriteLine("SAVE OK");
    }

    public static void Load()
    {


        if (!File.Exists("shop.json"))
            return;

        string json = File.ReadAllText("shop.json");

        ShopSaveData daten = JsonSerializer.Deserialize<ShopSaveData>(json);
        MessageBox.Show("LOAD START");
        MessageBox.Show("Money geladen: " + daten.Money);
        MessageBox.Show("Items geladen: " + (daten.Freigeschaltet?.Count ?? -1));
        if (daten == null)
            return;

        Money = daten.Money;

        Freigeschaltet = daten.Freigeschaltet ?? new List<ShopItems>();

        AktiverButton = daten.AktiverButton;
        AktiverBackground = daten.AktiverBackground;

        ShopUpdated?.Invoke();

        Console.WriteLine("LOAD OK");
    }

    // =========================
    // COLORS
    // =========================
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