using Application.Repositories;
using Application.UseCase.Category;
using Application.UseCase.Comment;
using Application.UseCase.Post;
using Application.UseCase.User;
using Autofac;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITeste.Fixed
{
    public class Fixture
    {
        public IContainer Container { get; set; }

        public Fixture()
        {
            var builder = new ContainerBuilder();

            /*  `POST CONTROLLER */

            builder.RegisterType<PostAddUseCase>().As<IPostAddUseCase>().InstancePerDependency();
            builder.RegisterType<PostUpdateUseCase>().As<IPostUpdateUseCase>().InstancePerDependency();
            builder.RegisterType<PostRemoveUseCase>().As<IPostRemoveUseCase>().InstancePerDependency();
            builder.RegisterType<PostGetByIdUseCase>().As<IPostGetByIdUseCase>().InstancePerDependency();
            builder.RegisterType<PostGetAllUseCase>().As<IPostGetAllUseCase>().InstancePerDependency();
            builder.RegisterType<PostRepository>().As<IPostWriteOnlyRepository>().InstancePerDependency();
            builder.RegisterType<PostRepository>().As<IPostReadOnlyRepository>().InstancePerDependency();

            /*  User CONTROLLER */
            builder.RegisterType<UserAddUseCase>().As<IUserAddUseCase>().InstancePerDependency();
            builder.RegisterType<UserUpdateUseCase>().As<IUserUpdateUseCase>().InstancePerDependency();
            builder.RegisterType<UserRemoveUseCase>().As<IUserRemoveUseCase>().InstancePerDependency();
            builder.RegisterType<UserGetByIdUseCase>().As<IUserGetByIdUseCase>().InstancePerDependency();
            builder.RegisterType<UserGetAllUseCase>().As<IUserGetAllUseCase>().InstancePerDependency();
            builder.RegisterType<UserRepository>().As<IUserWriteOnlyRepository>().InstancePerDependency();
            builder.RegisterType<UserRepository>().As<IUserReadOnlyRepository>().InstancePerDependency();

            /*  COMMENT CONTROLLER */
            builder.RegisterType<CommentAddUseCase>().As<ICommentAddUseCase>().InstancePerDependency();
            builder.RegisterType<CommentUpdateUseCase>().As<ICommentUpdateUseCase>().InstancePerDependency();
            builder.RegisterType<CommentRemoveUseCase>().As<ICommentRemoveUseCase>().InstancePerDependency();
            builder.RegisterType<CommentGetAllUseCase>().As<ICommentGetAllUseCase>().InstancePerDependency();
            builder.RegisterType<CommentGetByIdUseCase>().As<ICommentGetByIdUseCase>().InstancePerDependency();
            builder.RegisterType<CommentRepository>().As<ICommentWriteOnlyRepository>().InstancePerDependency();
            builder.RegisterType<CommentRepository>().As<ICommentReadOnlyRepository>().InstancePerDependency();

            /*CATEGORY CONTROLLER*/
            builder.RegisterType<CategoryAddUseCase>().As<ICategoryAddUseCase>().InstancePerDependency();
            builder.RegisterType<CategoryGetByIdUseCase>().As<ICategoryGetByIdUseCase>().InstancePerDependency();
            builder.RegisterType<CategoryGetAllUseCase>().As<ICategoryGetAllUseCase>().InstancePerDependency();
            builder.RegisterType<CategoryRepository>().As<ICategoryWriteOnlyRepository>().InstancePerDependency();
            builder.RegisterType<CategoryRepository>().As<ICategoryReadOnlyRepository>().InstancePerDependency();


            Container = builder.Build();
        }
    }
}