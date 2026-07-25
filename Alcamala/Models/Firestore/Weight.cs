using Fireblaze.Firestore;

namespace Alcamala.Models.Firestore;

[FirestoreCollection("weight")]
public class Weight : FirestoreDocument
{
    [FirestoreProperty("date")]
    public required DateTime EnteredOn { get; set; }

    [FirestoreProperty("weight")]
    public required int Value { get; set; }

    [FirestoreProperty("userId")]
    public required FirestoreId UserId { get; init; }
}
