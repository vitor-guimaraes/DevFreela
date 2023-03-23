using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillService (DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //MOVIDO PARA O GETALLSKILLSHANDLER

        //    private readonly DevFreelaDbContext _dbContext;
        //    private readonly string _connectionString;
        //    public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        //    {
        //        _dbContext = dbContext;
        //        _connectionString = configuration.GetConnectionString("DevFreelaCs"); //SÓ PRA UTILIZAR O DAPPER
        //    }
        //    public List<SkillViewModel> GetAll()
        //    {
        //        var skills = _dbContext.Skills;

        //        var skillsViewModel = skills
        //            .Select(s => new SkillViewModel(s.Id, s.Description))
        //            .ToList();

        //        _dbContext.SaveChanges();

        //        return skillsViewModel;
        //    }

        //    //GET ALL DAPPER
        //    public List<SkillViewModel> GetAll()
        //    {
        //        using (var sqlConnection = new SqlConnection(_connectionString))
        //        {
        //            sqlConnection.Open();

        //            var script = "SELECT Id, Description FROM Skills";

        //            return sqlConnection.Query<SkillViewModel>(script).ToList();
        //        }
        //    }
    }
}
