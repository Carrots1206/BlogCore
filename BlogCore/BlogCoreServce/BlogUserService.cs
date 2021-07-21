using BlogCoreModel.Entity;
using BlogCoreModel.Response;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreServce
{
    public class BlogUserService
    {
        private SqlSugarClient SqlSugarClient;
        public BlogUserService(SqlSugarHelper sqlSugarHelper) 
        {
            SqlSugarClient = sqlSugarHelper.Init();
        }

        public ResponseModel UserVerify(string email, string passWord,out string username) 
        {
            var user = SqlSugarClient.Queryable<BlogUser>().First(it => it.Email == email && it.PassWord == passWord);
            if (user == null)
            {
                username = string.Empty;
                return new ResponseModel()
                {
                    Code = 500,
                    Result = "用户名或密码不存在"
                };
            }
            else 
            {
                username = user.UserName;
                return new ResponseModel()
                {
                    Code = 200,
                    Result = "用户名密码正确"
                };
            }
        }
    }
}
