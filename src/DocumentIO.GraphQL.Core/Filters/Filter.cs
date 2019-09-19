using System.Linq;

namespace DocumentIO
{
	public interface IFilter<TEntity>
	{
		IQueryable<TEntity> Filter(IQueryable<TEntity> queryable);
	}
}