using Alcamala.Models.Firestore;
using Fireblaze.Auth.Interfaces;

namespace Alcamala.Models;

public class AlcamalaUser : User, IFirebaseUser
{
    public required string Uid { get; init; }
}
