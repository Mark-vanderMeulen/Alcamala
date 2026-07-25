using Fireblaze.Firestore;

namespace Alcamala.Models.Firestore.UserSettings.ChartSettings;

public class ChartSettings
{
    [FirestoreProperty("type")]
    public required string Type { get; set; }

    [FirestoreProperty("useFixedY")]
    public bool UseFixedY { get; set; }

    [FirestoreProperty("minY")]
    public int? MinY { get; set; }

    [FirestoreProperty("maxY")]
    public int? MaxY { get; set; }

    [FirestoreProperty("lines")]
    public List<Line> Lines { get; set; } = [];
}
