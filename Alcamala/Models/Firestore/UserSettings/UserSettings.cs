using Fireblaze.Firestore.Attributes;

namespace Alcamala.Models.Firestore.UserSettings;

[FirestoreCollection("userSettings")]
public class UserSettings
{
    [FirestoreProperty("locale")]
    public required string Locale { get; set; }

    [FirestoreProperty("theme")]
    public required string ThemeName { get; set; }

    [FirestoreProperty("chartSettings")]
    public List<ChartSettings.ChartSettings> ChartSettings { get; set; } = [];
}
