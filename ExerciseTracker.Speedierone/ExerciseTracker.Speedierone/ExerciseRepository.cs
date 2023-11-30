using ExerciseTracker.Speedierone.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace ExerciseTracker.Speedierone
{
    public class ExerciseRepository : IExerciseRepository
    {
        public readonly ExerciseDbContext _context;
        public ExerciseRepository(ExerciseDbContext context)
        {
            _context = context;
        }
        public void Add(Exercises exercises)
        {
            _context.Exercises.Add(exercises);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {

        }

        public IEnumerable<Exercises> GetAll()
        {    
            return _context.Exercises.ToList();
        }
        public List<Exercises> GetById(int id)
        {
            Exercises result = _context.Exercises.SingleOrDefault(e => e.Id == id);

            List<Exercises> resultList = result != null ? new List<Exercises> { result } : new List<Exercises>();

            return resultList;
        }

        public void Update(Exercises exercisesToUpdate)
        {
            UserInput session = new UserInput();
            session.GetSessionForUpdate(exercisesToUpdate);
            _context.Update(exercisesToUpdate);
            _context.SaveChanges();
        }
        public void Save()
        {

        }
    }
}
