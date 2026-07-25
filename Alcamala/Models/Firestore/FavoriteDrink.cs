using Fireblaze.Firestore;

namespace Alcamala.Models.Firestore;

[FirestoreCollection("favoriteDrinks")]
public class FavoriteDrink : FirestoreDocument
{
    [FirestoreProperty("name")]
    public required string Name { get; set; }

    [FirestoreProperty("amount")]
    public required int Amount { get; set; }

    [FirestoreProperty("userId")]
    public required FirestoreId UserId { get; init; }
}
