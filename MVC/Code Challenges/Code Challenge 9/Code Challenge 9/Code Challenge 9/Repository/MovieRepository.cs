using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Code_Challenge_9.Models;

namespace Code_Challenge_9.Repository
{
    public class MovieRepository<T> : IMovieRepository<T> where T : class
    {
        MovieContext db;
        DbSet<T> dbset;

        public MovieRepository()
        {
            db = new MovieContext();
            dbset = db.Set<T>();
        }
        public void Create(T obj)
        {
            dbset.Add(obj);
        }

        public void Delete(object Id)
        {
            T getModel = dbset.Find(Id);
            dbset.Remove(getModel);
        }

        public T DisplayMoviesByDirector(object Director)
        {
            return dbset.Find(Director);
        }

        public T DisplayMoviesByYear(object Year)
        {
            return dbset.Find(Year);
        }
        public T GetById(object Id)
        {
            return dbset.Find(Id);
        }
        public void Edit(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList(); 
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}