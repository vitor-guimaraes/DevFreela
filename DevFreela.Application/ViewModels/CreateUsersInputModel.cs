using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Application.ViewModels
{
    public class CreateUsersInputModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}
