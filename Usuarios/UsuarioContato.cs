using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Usuarios
{
    public class UsuarioContato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UsuariosContato")]
        public string Nome { get; set; } = null!;

        public string Sobrenome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public Int64 Telefone { get; set; }
    }
}