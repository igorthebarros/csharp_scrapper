using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> filter);
        T GetById(string id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
    public class Repository<T> : IRepository<T>
    {
        private readonly IMongoCollection<T> _collection;

        public Repository(Context context, string collectionName)
        {
            _collection = context.GetCollection<T>(collectionName);
        }

        public IEnumerable<T> GetAll()
        {
            //return _collection.Find(_ => true).ToList();
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            //return _collection.Find(filter).ToList();
            throw new NotImplementedException();
        }

        public T GetById(string id)
        {
            //var objectId = new ObjectId(id);
            //return _collection.Find(entity => entity.Id == objectId).FirstOrDefault();
            throw new NotImplementedException();
        }

        public Task Insert(T entity)
        {
            //_collection.InsertOne(entity);
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            //var objectId = entity.Id as ObjectId;
            //_collection.ReplaceOne(e => e.Id == objectId, entity);
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            //var objectId = entity.Id as ObjectId;
            //_collection.DeleteOne(e => e.Id == objectId);
            throw new NotImplementedException();
        }

    }
}
