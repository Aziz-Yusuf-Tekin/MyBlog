using Microsoft.EntityFrameworkCore;
using MyBlog.Shared.Data.Abstract;
using MyBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Shared.Data.Concrete.EntityFramework
{
	public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
	{
		protected readonly DbContext _contex;

		public EfEntityRepositoryBase(DbContext contex)
		{
			_contex = contex;
		}


		#region AddAsync
		public async Task<TEntity> AddAsync(TEntity entity)
		{
			await _contex.Set<TEntity>().AddAsync(entity);
			return entity;
		}
		#endregion

		#region AnyAsync

		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _contex.Set<TEntity>().AnyAsync(predicate);
		}


		#endregion


		////CountAsync
		//public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
		//{
		//	return await (predicate == null ? _contex.Set<TEntity>().CountAsync() : _contex.Set<TEntity>().CountAsync(predicate));
		//}


		#region DeleteAsync
		public async Task DeleteAsync(TEntity entity)
		{
			await Task.Run(() => { _contex.Set<TEntity>().Remove(entity); });
		}
		#endregion

		#region GettAllAsync
	
		public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = _contex.Set<TEntity>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			if (includeProperties.Any())
			{
				foreach (var includeProperty in includeProperties)
				{
					query = query.Include(includeProperty);
				}
			}

			return await query.ToListAsync();
		}


		#endregion

		#region GetAsync
		public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = _contex.Set<TEntity>();
			query = query.Where(predicate);
			if (includeProperties.Any())
			{
				foreach (var includeProperty in includeProperties)
				{
					query = query.Include(includeProperty);
				}
			}
			return await query.FirstOrDefaultAsync();
		}
		#endregion

		#region UpdateAsync
		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			await Task.Run(() => { _contex.Set<TEntity>().Update(entity); });
			return entity;
		}

		#endregion

	}
}
