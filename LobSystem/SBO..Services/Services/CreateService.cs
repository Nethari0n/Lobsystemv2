using Microsoft.EntityFrameworkCore;
using SBO.Lobsystem.Domain.Data;
using SBO.LobSystem.Services.Interface;
using System.Threading.Tasks;

namespace SBO.LobSystem.Services.Services
{
    public class CreateService : ICreateService
    {

        private readonly ApplicationDBContext _context;

        public CreateService(ApplicationDBContext lobsContext)
        {
            _context = lobsContext;
        }

        public async Task CreateEntity<T>(T entity) where T : class
        {

            _context.Add(entity);

            await _context.SaveChangesAsync();
            _context.Entry(entity).State = EntityState.Detached;
        }


        public async Task DeleteEntity<T>(T entity) where T : class
        {
            if ( _context.Entry(entity).State == EntityState.Detached )
            {
                _context.Attach(entity);
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity<T>(T entity) where T : class
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}
