using Fireblaze.Firestore.Attributes;

namespace Alcamala.Models.Firestore.UserSettings.ChartSettings;

public record Line
{
    [FirestoreProperty("name")]
    public required string Name { get; set; }

    [FirestoreProperty("value")]
    public required double Value { get; set; }

    [FirestoreProperty("color")]
    public required string ColorName { get; set; }

    [FirestoreProperty("showLabel")]
    public bool ShowLabel { get; set; } = true;
}
