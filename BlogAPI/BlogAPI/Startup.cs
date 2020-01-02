using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Application.UseCase.Category;
using Infrastructure.Repository;
using Application.Repositories;
using Application.UseCase.Comment;
using Application.UseCase.Post;
using Application.UseCase.User;

namespace BlogAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            //Category
            services.AddScoped<ICategoryAddUseCase, CategoryAddUseCase>();
            services.AddScoped<ICategoryGetByIdUseCase, CategoryGetByIdUseCase>();
            services.AddScoped<ICategoryGetAllUseCase, CategoryGetAllUseCase>();
            services.AddScoped<ICategoryWriteOnlyRepository, CategoryRepository>();
            services.AddScoped<ICategoryReadOnlyRepository, CategoryRepository>();

            //Comment
            services.AddScoped<ICommentAddUseCase, CommentAddUseCase>();
            services.AddScoped<ICommentRemoveUseCase, CommentRemoveUseCase>();
            services.AddScoped<ICommentUpdateUseCase, CommentUpdateUseCase>();
            services.AddScoped<ICommentGetAllUseCase, CommentGetAllUseCase>();
            services.AddScoped<ICommentGetByIdUseCase, CommentGetByIdUseCase>();
            services.AddScoped<ICommentWriteOnlyRepository, CommentRepository>();
            services.AddScoped<ICommentReadOnlyRepository, CommentRepository>();
           

            //Post
            services.AddScoped<IPostAddUseCase, PostAddUseCase>();
            services.AddScoped<IPostRemoveUseCase, PostRemoveUseCase>();
            services.AddScoped<IPostUpdateUseCase, PostUpdateUseCase>();
            services.AddScoped<IPostGetByIdUseCase, PostGetByIdUseCase>();
            services.AddScoped<IPostGetAllUseCase, PostGetAllUseCase>();
            services.AddScoped<IPostWriteOnlyRepository, PostRepository>();
            services.AddScoped<IPostReadOnlyRepository, PostRepository>();

            //User
            services.AddScoped<IUserAddUseCase, UserAddUseCase>();
            services.AddScoped<IUserRemoveUseCase, UserRemoveUseCase>();
            services.AddScoped<IUserUpdateUseCase, UserUpdateUseCase>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserGetByIdUseCase, UserGetByIdUseCase>();
            services.AddScoped<IUserGetAllUseCase, UserGetAllUseCase>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gang of Five - Blog API", Version = "v1" });
                var xmlPaths = AppDomain.CurrentDomain.BaseDirectory + @"BlogAPI.xml";
                c.IncludeXmlComments(xmlPaths);
            });

            using ApplicationContext context = new ApplicationContext();
            context.Database.Migrate();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gang of Five - Blog API V1");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
