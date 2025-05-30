using TreesTestTask.Dal.Contracts.Entities;
using TreesTestTask.Dal.Contracts.Models;

namespace TreesTestTask.Migrations.Extensions
{
	public static class JournalExtensions
	{
		public static IQueryable<JournalRecord> ApplyFilter(this IQueryable<JournalRecord> query, JournalFilterModel filter)
		{
			if (filter == null)
				return query;

			if (!string.IsNullOrEmpty(filter.SearchText))
			{
				query = query.Where(j => j.BodyParameters.Contains(filter.SearchText)
				                      || j.QueryParameters.Contains(filter.SearchText)
				                      || j.StackTrace.Contains(filter.SearchText));
			}
			if (filter.From.HasValue)
			{
				query = query.Where(j => j.CreatedAt >= filter.From.Value);
			}
			if (filter.To.HasValue)
			{
				query = query.Where(j => j.CreatedAt <= filter.To.Value);
			}

			return query;
		}
	}
}