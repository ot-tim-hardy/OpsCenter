using System;
using System.Collections.Generic;
using System.Linq;

namespace OpsCenter.Models
{
	public interface IDatastore
	{
		void CommitChanges();
		void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new();
		void Delete<T>(T item) where T : class, new();
		void DeleteAll<T>() where T : class, new();
		T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new();
		IQueryable<T> All<T>() where T : class, new();
		void Add<T>(T item) where T : class, new();
		void Add<T>(IEnumerable<T> items) where T : class, new();
	}
}