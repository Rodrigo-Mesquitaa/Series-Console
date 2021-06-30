using Series.Class;
using Series.Interfaces;
using System.Collections.Generic;

namespace Series.Repositories
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> seriesList = new List<Serie>();

        public List<Serie> FindAll()
        {
            return seriesList;
        }

        public Serie FindById(int id)
        {
            return seriesList[id];
        }

        public void Create(Serie entity)
        {
            seriesList.Add(entity);
        }

        public void Delete(int id)
        {
            seriesList[id].Delete();
        }

        public void Update(int id, Serie entity)
        {
            seriesList[id] = entity;
        }

        public int NextId()
        {
            return seriesList.Count;
        }
    }
}