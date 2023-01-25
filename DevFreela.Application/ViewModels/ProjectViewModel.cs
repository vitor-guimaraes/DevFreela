<<<<<<< HEAD
﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
=======
﻿using DevFreela.Core.Enums;
using System;
>>>>>>> EFCore

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {

        public ProjectViewModel(int id, string title, DateTime createdAt, ProjectStatusEnum status)
        {
            Id = id;
            Title = title;
            CreatedAt = createdAt;
            Status = status;
        }

<<<<<<< HEAD
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
=======
        public int Id { get; private set; }
>>>>>>> EFCore
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }

    }
}
