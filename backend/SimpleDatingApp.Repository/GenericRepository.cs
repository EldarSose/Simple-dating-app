using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDatingApp.Repository
{
	public interface IGenericRepository<TEntity, TKey>
	{
		//IQueryable<TEntity> GetAll();
		//TEntity GetById(TKey key);
		//void Add(TEntity entity);
		//void Update(TEntity entity);
	}
	public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
	{
		////private readonly SimpleDatingAppDBContext simpleDatingAppDBContext;
		//private readonly DbSet<TEntity> dbSet;

		////public GenericRepository(SimpleDatingAppDBContext simpleDatingAppDBContext)
		////{
		////	this.simpleDatingAppDBContext = simpleDatingAppDBContext;
		////	dbSet = simpleDatingAppDBContext.Set<TEntity>();
		////}

		//public void Add(TEntity entity)
		//{
		//	dbSet.Add(entity);
		//	//simpleDatingAppDBContext.SaveChanges();
		//}

		//public IQueryable<TEntity>  GetAll()
		//{
		//	return dbSet.AsNoTracking();
		//}

		//public TEntity GetById(TKey key)
		//{
		//	return dbSet.Find(key);
		//}

		//public void Update(TEntity entity)
		//{
		//	dbSet.Update(entity);
		//	simpleDatingAppDBContext.SaveChanges();
		//}
	}
}
