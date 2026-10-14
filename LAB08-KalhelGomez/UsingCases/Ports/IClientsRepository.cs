using LAB08_KalhelGomez.Models;

namespace LAB08_KalhelGomez.UsingCases.Ports;

public interface IClientsRepository
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int id);
    Task<List<Client>> GetByNameAsync(string name);
    Task<List<Client>> GetClientsWhoBoughtProductAsync(int productId);
    Task<Client> CreateAsync(Client entity);
    Task<Client?> UpdateAsync(int id, Client entity);
    Task<bool> DeleteAsync(int id);
}
