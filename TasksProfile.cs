using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModels;

namespace EntityFramwork
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<Tasks, TasksViewModel>();
        }
    }
}
