using Fireblaze.Core;
using Fireblaze.Firestore.Attributes;
using Fireblaze.Firestore.Models;

namespace Alcamala.Models.Firestore;

[FirestoreCollection("drinks")]
public class Drink : FirestoreDocument
{
    [FirestoreProperty("name")]
    public required string Name { get; set; }

    [FirestoreProperty("amount")]
    public required int Amount { get; set; }

    [FirestoreProperty("consumed")]
    public required DateTime ConsumedOn { get; set; }

    [FirestoreProperty("userId")]
    public required FirestoreId UserId { get; init; }
}
