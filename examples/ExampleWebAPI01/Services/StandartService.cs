using ExampleWebAPI01.Models;

namespace ExampleWebAPI01.Services
{
    public class StandartService
    {
        private readonly ApplicationContext2415 _context;
        
        public StandartService(ApplicationContext2415 context) 
        {
            _context = context;
        }

        public IEnumerable<Standart> GetAll()
        {
            return _context.Standarts.ToList();
        }

        public Standart? Get(int id)
        {
            return _context.Standarts.Find(id);
        }
    }
}
