using Logitar.Data;
using Logitar.Data.PostgreSQL;

namespace SkillCraft.Infrastructure.PostgreSQL;

internal class PostgresHelper : SqlHelper
{
  public override IQueryBuilder Query(TableId table) => PostgresQueryBuilder.From(table);

  protected override ConditionalOperator CreateOperator(string pattern) => PostgresOperators.IsLikeInsensitive(pattern);
}
