using System.Threading.Tasks;
using Back.src.ProEventos.Domain;

namespace Back.src.ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {      
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);

    }

}