using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_9.Repository
{
    public interface IMovieRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        void Create(T obj);
        void Edit(T obj);
        void Delete(object Id);
        void Save();
        T GetById(object Id);
        T DisplayMoviesByYear(object Year);
        T DisplayMoviesByDirector(object Director);
    }
}
