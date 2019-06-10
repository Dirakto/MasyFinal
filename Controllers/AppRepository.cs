using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VSCode.Models;
using VSCode.Models.bohater;


namespace VSCode.Controllers
{
    public class AppRepository : IAppRepository
    {
        private AppDbContext _context;

        public AppRepository(AppDbContext context){
            _context = context;
        }

        public ICollection<Bohater> Bohaterowie => _context.Bohaterowie.Include(b => b.Umiejetnosci).ToList();

        public void SaveAsync() => _context.SaveChangesAsync();
    }
}