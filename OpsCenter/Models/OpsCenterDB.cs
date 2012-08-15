using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpsCenter.Models {
	public class OpsCenterDB : DbContext, IDatastore
	{
		public DbSet<Environment> Environments { get; set; }
		public DbSet<Configuration> Configurations { get; set; }
		
//		protected override void OnModelCreating(DbModelBuilder modelBuilder)
//		{
//			modelBuilder
//				.Configurations
//				.Add(new ConfigurationMap());
//		}

		#region IDatastore implementation
		public void CommitChanges() {
			SaveChanges();
		}

		public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new() {
			var query = All<T>().Where(expression);
			foreach (T item in query) {
				Delete(item);
			}
		}

		public void Delete<T>(T item) where T : class, new() {
			Set<T>().Remove(item);
		}

		public void DeleteAll<T>() where T : class, new() {
			var query = All<T>();
			foreach (var item in query) {
				Delete(item);
			}
		}

		public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new() {
			return All<T>().FirstOrDefault(expression);
		}

		public IQueryable<T> All<T>() where T : class, new() {
			return Set<T>().AsQueryable<T>();
		}

		public void Add<T>(T item) where T : class, new() {
			Set<T>().Add(item);
		}

		public void Add<T>(IEnumerable<T> items) where T : class, new() {
			foreach (T item in items) {
				Add(item);
			}
		}
		#endregion IDatastore implementation
	}
}