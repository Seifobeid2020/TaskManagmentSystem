using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.ViewModels
{
    public class TasksCategoriesViewModel
    {
        public int? CategoryId { get; set; }
      
        public int? TaskId { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Tasks Task { get; set; }
    }
}
