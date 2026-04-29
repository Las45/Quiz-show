using System.Collections.Generic;

public class TranslatorClass
{
    private Dictionary<string, string> deToEn = new Dictionary<string, string>()
    {
        {"hallo", "hello"},
        {"tschüss", "bye"},
        {"danke", "thank you"},
        {"bitte", "please"},
        {"ja", "yes"},
        {"nein", "no"},
        {"haus", "house"},
        {"auto", "car"},
        {"baum", "tree"},
        {"wasser", "water"},
        {"essen", "food"},
        {"trinken", "drink"},
        {"freund", "friend"},
        {"schule", "school"},
        {"arbeit", "work"},
        {"zeit", "time"},
        {"tag", "day"},
        {"nacht", "night"},
        {"sonne", "sun"},
        {"mond", "moon"}

    };

    private Dictionary<string, string> enToDe = new Dictionary<string, string>();

    public TranslatorClass()
    {

        foreach (var pair in deToEn)
        {
            enToDe[pair.Value] = pair.Key;
        }
    }

    // Deutsch zu Englisch
    public string TranslateDeToEn(string word)
    {
        word = word.ToLower();

        if (deToEn.ContainsKey(word))
            return deToEn[word];

        return "Nicht gefunden";
    }

    // Englisch zu Deutsch
    public string TranslateEnToDe(string word)
    {
        word = word.ToLower();

        if (enToDe.ContainsKey(word))
            return enToDe[word];

        return "Not found";
    }
}