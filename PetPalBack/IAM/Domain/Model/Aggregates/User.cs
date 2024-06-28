using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using System.Text.Json.Serialization;

namespace PetPalBack.IAM.Domain.Model.Aggregates
{
    public class User(string username, string passwordHash)
    {
        public User() : this(string.Empty, string.Empty) { }

        public int Id { get; }

        public string Username { get; private set; } = username;
        public IEnumerable<Pet> pet { get; set; }

        [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

        public User UpdateUsername(string username)
        {
            Username = username;
            return this;
        }

        public User UpdatePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
            return this;
        }

    }
}
