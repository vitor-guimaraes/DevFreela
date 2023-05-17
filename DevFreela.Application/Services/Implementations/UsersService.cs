using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class UsersService : IUsersService
    {

        private readonly DevFreelaDbContext _dbContext;
        public UsersService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public int Create(CreateUsersInputModel inputModel)
        //{
        //    var user = new User(
        //                        inputModel.Fullname, 
        //                        inputModel.Email, 
        //                        inputModel.BirthDate, 
        //                        inputModel.Active
        //                        );

        //    _dbContext.Users.Add(user);

        //    _dbContext.SaveChanges();

        //    return user.Id;
        //}

        //public void Delete(int id)
        //{
        //    var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

        //    user.Remove();

        //    _dbContext.SaveChanges();
        //}

        //public List<UsersViewModel> GetAllUsers()
        //{
        //    var users = _dbContext.Users;

        //    var usersViewModel = users.Select(u => new UsersViewModel
        //                                                        (u.Fullname, 
        //                                                        u.Id, 
        //                                                        u.Active)).ToList();

        //    return usersViewModel;
        //}

        //public UsersDetailsViewModel GetById(int id)
        //{
        //    var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

        //    if (user == null)
        //        return null;

        //    var usersDetailsViewModel = new UsersDetailsViewModel(
        //                                user.Id,
        //                                user.Fullname,
        //                                user.Email,
        //                                user.OwnedProjects,
        //                                user.Skills,
        //                                user.Active
        //                                );

        //    return usersDetailsViewModel;
        //}

        //public void Update(UpdateUsersInputModel inputModel)
        //{
        //    var user = _dbContext.Users.SingleOrDefault(u => u.Id == inputModel.Id);

        //    user.Update(user.Id, inputModel.Fullname, 
        //                inputModel.Email, inputModel.OwnedProjects, 
        //                inputModel.Skills, inputModel.Active);

        //    _dbContext.SaveChanges();
        //}
    }
}
