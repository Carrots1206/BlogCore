using BlogCoreModel.Entity;
using BlogCoreModel.Request;
using BlogCoreModel.Response;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogCoreService
{
    public class BlogPostsService
    {
        public SqlSugarClient sugarClient;
        public string sqllog = string.Empty;
        public BlogPostsService(SqlSugarHelper sqlSugarHelper)
        {
            sugarClient = sqlSugarHelper.Init();
        }

        #region 获取博客列表
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetBlogPostsList() 
        {
            var PostsList = sugarClient.Queryable<BlogPosts>().ToList().OrderByDescending(c=>c.AddTime);
            if (PostsList != null)
            {
                ResponseModel responseModel = new ResponseModel();
                responseModel.Code = 200;
                responseModel.Result = "博客列表获取成功";
                responseModel.Data = new List<BlogPosts>();
                foreach (var posts in PostsList) 
                {
                    responseModel.Data.Add(new BlogPosts 
                    {
                        Id= posts.Id,
                        Title = posts.Title,
                        Details = posts.Details,
                        AddTime = posts.AddTime
                    });
                }
                return responseModel;
            }
            else 
            {
                return new ResponseModel()
                {
                    Code = 0,
                    Result = "博客列表获取失败"
                };
            }
        }
        #endregion

        #region 根据内容获取博客列表
        /// <summary>
        /// 根据内容获取博客列表
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetBlogPostsList(string PostsTitle)
        {
            var PostsList = sugarClient.Queryable<BlogPosts>().Where(t => t.Title.Contains(PostsTitle)).ToList();

            if (PostsList != null)
            {
                ResponseModel responseModel = new ResponseModel();
                responseModel.Code = 200;
                responseModel.Result = "获取成功";
                responseModel.Data = new List<BlogPosts>();
                var aa = PostsList.Count;
                foreach (var posts in PostsList)
                {
                    responseModel.Data.Add(new BlogPosts
                    {
                        Id = posts.Id,
                        Title = posts.Title,
                        Details = posts.Details,
                        AddTime = posts.AddTime
                    });
                }
                return responseModel;
            }
            else
            {
                return new ResponseModel()
                {
                    Code = 0,
                    Result = "博客列表获取失败"
                };
            }
        }
        #endregion

        #region 添加一条博客
        /// <summary>
        /// 添加博客
        /// </summary>
        /// <param name="addPosts"></param>
        /// <returns></returns>
        public ResponseModel AddBlogPosts(AddPosts addPosts)
        {
            BlogPosts blogPosts = new BlogPosts() 
            {
                Title = addPosts.Title,
                Details = addPosts.Details,
                AddTime = DateTime.Now
            };
            var count = sugarClient.Insertable(blogPosts).ExecuteCommand();
            if (count > 0)
            {
                return new ResponseModel() {Code=200,Result="数据添加成功" };
            }
            else 
            {
                return new ResponseModel() { Code = 0, Result = "数据添加失败" };
            }
        }
        #endregion
    }
}
