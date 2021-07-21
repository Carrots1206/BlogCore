using BlogCoreModel.Entity;
using SqlSugar;
using System;

namespace BlogCoreServce
{
    public class SqlSugarHelper
    {
        public SqlSugarClient Init()
        {
            SqlSugarClient sqlSugar = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=.;uid=sa;pwd=sa;database=Blog",//连接符字串
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });
            sqlSugar.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(BlogPosts));
            sqlSugar.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(BlogUser));
            sqlSugar.Aop.OnLogExecuted = (sql, pars) =>
            {
                System.Diagnostics.Debug.WriteLine("SQL语句是：" + sql);
            };
            return sqlSugar;
        }
    }
}
