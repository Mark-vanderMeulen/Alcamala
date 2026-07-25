using Fireblaze.Firestore;

namespace Alcamala.Models.Firestore;

[FirestoreCollection("users")]
public class User : FirestoreDocument
{
    [FirestoreProperty("email")]
    public string? Email { get; set; }

    [FirestoreProperty("firstName")]
    public string? FirstName { get; set; }

    [FirestoreProperty("lastName")]
    public string? LastName { get; set; }

    [FirestoreProperty("age")]
    public int Age { get; set; }
}
