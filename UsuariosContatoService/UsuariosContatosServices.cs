using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Usuarios;
using UsuariosDatabaseSettings;
namespace UsuariosContatoService
{
    public class UsuariosContatosServices
    {
        private readonly IMongoCollection<UsuarioContato> _usuarioContato;

        public UsuariosContatosServices(IOptions<UsuariosContatoDatabaseSettings> usuariosContatosServices)
        {
            var mongoClient = new MongoClient(usuariosContatosServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(usuariosContatosServices.Value.UsuarioDatabase);

            _usuarioContato = mongoDatabase.GetCollection<UsuarioContato>(usuariosContatosServices.Value.UsuarioContatoCollection);
        }

        public async Task<List<UsuarioContato>> GetClientesAsync() =>
           await _usuarioContato.Find(x => true).ToListAsync();

        public async Task<UsuarioContato> GetUsuarioAsync(string id) =>
            await _usuarioContato.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UsuarioContato usuarioContato) =>
        await _usuarioContato.InsertOneAsync(usuarioContato);

        public async Task UpdateAsync(string id, UsuarioContato usuarioContato) =>
            await _usuarioContato.ReplaceOneAsync(x => x.Id == id, usuarioContato);

        public async Task RemoveAsync(string id) =>
            await _usuarioContato.DeleteOneAsync(x => x.Id == id);

    }
}