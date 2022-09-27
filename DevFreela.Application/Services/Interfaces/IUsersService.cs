using DevFreela.Application.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUsersService
    {
        List<UsersViewModel> GetAllUsers(string query);
        UsersDetailsViewModel GetById(int id);
        int Create(CreateUsersInputModel inputModel);
        void Update(UpdateUsersInputModel inputModel);
        void Delete(int id);
    }
}
