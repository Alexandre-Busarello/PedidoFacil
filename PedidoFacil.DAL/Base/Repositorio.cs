using System;
using System.Linq;
using System.Data.Entity;
using System.Collections;
using System.Collections.Generic;

namespace PedidoFacil.DAL.Base
{
	public abstract class Repositorio<TEntity> : IDisposable, IRepositorio<TEntity> where TEntity : class
	{
	    PedidoFacilContexto ctx = new PedidoFacilContexto();

		public static IList<T> CastToList<T>(IEnumerable source)
		{
			return new List<T>(source.Cast<T>());
		}


		public IQueryable<TEntity> GetAll()
		{
			return ctx.Set<TEntity>();
		}

		public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
		{
			return GetAll().Where(predicate).AsQueryable();
		}

		public TEntity Find(params object[] key)
		{
			return ctx.Set<TEntity>().Find(key);
		}

		public void Atualizar(TEntity obj)
		{
			ctx.Entry(obj).State = EntityState.Modified;
		}

		public void SalvarTodos()
		{
			ctx.SaveChanges();
		}

		public void Adicionar(TEntity obj)
		{
			ctx.Set<TEntity>().Add(obj);
		}

		public void Excluir(Func<TEntity, bool> predicate)
		{
			ctx.Set<TEntity>()
				.Where(predicate).ToList()
				.ForEach(del => ctx.Set<TEntity>().Remove(del));
		}

		public void Dispose()
		{
			ctx.Dispose();
		}	
			
	}
}

