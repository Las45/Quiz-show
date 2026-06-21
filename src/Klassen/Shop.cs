using Quiz_show;
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
    private static MainWindow GetMainWindow() => (MainWindow)Application.Current.MainWindow;

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


    public static async void Save()
    {
        if (GetMainWindow() == null)
        {
            return;
        }
        string userId = GetMainWindow().client.Auth.CurrentUser?.Id;
        if (string.IsNullOrEmpty(userId)) 
            return;
        ShopSaveData daten = new ShopSaveData
        {
            Money = Money,
            Freigeschaltet = Freigeschaltet,
            AktiverButton = AktiverButton,
            AktiverBackground = AktiverBackground
        };

        string json = JsonSerializer.Serialize(daten, new JsonSerializerOptions
        {
            WriteIndented = false
        });

        try
        {
            // Der Code für das Speichern wurde teilweise von dem progress speichern übernommen, welcher teils von Ki stammt.
            ShopSaveDataModel model = new ShopSaveDataModel
            {
                UserId = userId,
                ShopData = json
            };

            await GetMainWindow().client.From<ShopSaveDataModel>().Upsert(model);
            Logging.logger.Debug("Shop wurde gesaved");

        }
        catch (Exception ex)
        {
            Logging.logger.Error("Es konnte nicht auf Supabase gespeichert werden: " + ex.Message);
        }

    }

    public static async void Load()
    {
        if (GetMainWindow() == null) 
            return;

        string userId = GetMainWindow().client.Auth.CurrentUser?.Id;
        if (string.IsNullOrEmpty(userId)) 
            return;

        try
        {
            // Code wurde teilweise von Progress übernommen welcher teils von Ki stammt.
            ShopSaveDataModel? row = await GetMainWindow().client
                .From<ShopSaveDataModel>()
                .Where(x => x.UserId == userId)
                .Single();

            if (row?.ShopData == null) 
                return;

            ShopSaveData daten = JsonSerializer.Deserialize<ShopSaveData>(row.ShopData);
            if (daten == null) 
                return;

            Money = daten.Money;
            Freigeschaltet = daten.Freigeschaltet ?? new List<ShopItems>();
            AktiverButton = daten.AktiverButton;
            AktiverBackground = daten.AktiverBackground;

            ShopUpdated?.Invoke();
            Logging.logger.Debug("Shop wurde geladen");
        }
        catch (Exception ex)
        {
            Logging.logger.Error("Es konnte nicht geladen werden: " + ex.Message);
        }
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