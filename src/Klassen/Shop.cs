using Quiz_show;
using Quiz_show.src.Klassen;
using Supabase.Postgrest.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

public static class Shop
{
    public static double Money = 0;
    public static event Action ShopUpdated;

    public static List<ShopItems> Freigeschaltet = new List<ShopItems>();
    public static ShopItems AktiverButton = ShopItems.OriginalButton;
    public static ShopItems AktiverBackground = ShopItems.OriginalBackground;

    private static MainWindow GetMainWindow() => (MainWindow)Application.Current.MainWindow;

    public static async void Purchase(ShopItems item)
    {
        if (Freigeschaltet.Contains(item))
        {
            Select(item);
            await Save();

            Logging.logger.Debug($"Shop item selected: {item}");
            ShopUpdated?.Invoke();
            return;
        }

        double price = GetPrice(item);
        if (Money >= price)
        {
            Money -= price;
            Freigeschaltet.Add(item);
            Select(item);

            await SaveItemPurchase(item);
            await Save();

            Logging.logger.Debug($"Shop item purchased: {item}");
            ShopUpdated?.Invoke();
        }
        else
        {
            MessageBox.Show("Nicht genug geld");
        }
    }

    public static void Select(ShopItems item)
    {
        if (item.ToString().EndsWith("Button"))
        {
            AktiverButton = item;
        }
        else if (item.ToString().EndsWith("Background"))
        {
            AktiverBackground = item;
        }
    }

    private static async Task SaveItemPurchase(ShopItems item)
    {
        string userId = GetMainWindow().client.Auth.CurrentUser?.Id;
        if (string.IsNullOrEmpty(userId)) return;

        try
        {
            UserShopItemModel model = new UserShopItemModel
            {
                UserId = userId,
                ItemId = (int)item,
                UnlockedAt = DateTime.UtcNow,
                TimeStamp = DateTime.UtcNow
            };

            // Hier nutzen wir .Insert() statt .Upsert(), da ein Kauf immer ein neuer Eintrag ist.
            await GetMainWindow().client.From<UserShopItemModel>().Insert(model);
        }
        catch (Exception ex)
        {
            Logging.logger.Error($"Fehler beim Speichern des gekauften Items: {ex.Message}");
        }
    }

    public static async Task Save()
    {
        string userId = GetMainWindow().client.Auth.CurrentUser?.Id;
        if (string.IsNullOrEmpty(userId)) return;

        try
        {
            UserProfileModel profile = new UserProfileModel
            {
                UserId = userId,
                Money = Money,
                AktiverButton = (int)AktiverButton,
                AktiverBackground = (int)AktiverBackground,
                TimeStamp = DateTime.UtcNow
            };

            await GetMainWindow().client.From<UserProfileModel>().Upsert(profile);
            Logging.logger.Debug("Shop-Profil erfolgreich in Supabase gespeichert");
        }
        catch (Exception ex)
        {
            Logging.logger.Error($"Fehler beim Speichern des Profils: {ex.Message}");
        }
    }

    public static async Task Load()
    {
        string userId = GetMainWindow().client.Auth.CurrentUser?.Id;
        if (string.IsNullOrEmpty(userId)) return;

        try
        {
            // 1. Profil (Geld & ausgewählte Styles) laden
            UserProfileModel profileRes = await GetMainWindow().client
                .From<UserProfileModel>()
                .Where(x => x.UserId == userId)
                .Single();

            if (profileRes != null)
            {
                Money = profileRes.Money;
                AktiverButton = (ShopItems)profileRes.AktiverButton;
                AktiverBackground = (ShopItems)profileRes.AktiverBackground;
            }

            // 2. Freigeschaltete Items laden
            ModeledResponse<UserShopItemModel> itemsRes = await GetMainWindow().client
                .From<UserShopItemModel>()
                .Where(x => x.UserId == userId)
                .Get();

            Freigeschaltet.Clear();
            if (itemsRes?.Models != null)
            {
                foreach (UserShopItemModel item in itemsRes.Models)
                {
                    Freigeschaltet.Add((ShopItems)item.ItemId);
                }
            }

            ShopUpdated?.Invoke();
            Logging.logger.Debug("Shop-Daten aus Supabase geladen");
        }
        catch (Exception ex)
        {
            Logging.logger.Error($"Fehler beim Laden der Shop-Daten: {ex.Message}");
        }
    }

    public static double GetPrice(ShopItems item)
    {
        switch (item)
        {
            case ShopItems.RotButton: return 100;
            case ShopItems.GoldButton: return 250;
            case ShopItems.GrünBackground: return 150;
            case ShopItems.SilberBackground: return 300;
            default: return 0;
        }
    }

    public static Color GetButtonColor()
    {
        switch (AktiverButton)
        {
            case ShopItems.RotButton: return Colors.Red;
            case ShopItems.GoldButton: return Colors.Gold;
            default: return Colors.SkyBlue;
        }
    }

    public static Color GetBackgroundColor()
    {
        switch (AktiverBackground)
        {
            case ShopItems.GrünBackground: return Colors.Green;
            case ShopItems.SilberBackground: return Colors.Silver;
            default: return Colors.White;
        }
    }
}