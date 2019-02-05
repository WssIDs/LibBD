using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibDB.DAL
{
    public class TestCard
    {
        [HiddenInput]
        public int Id { get; set; } // id автора

        [Required(ErrorMessage = "Введите год заполнения карточки")]
        [Display(Name = "Год")]
        public int Year { get; set; } // Год заполнения карточки

        [Display(Name = "Шапка карточки")]
        public string Header { get; set; } // Шапка карточки
        [Required(ErrorMessage = "Введите Заглавие карточки")]
        [Display(Name = "Заглавие карточки")]
        public string Title { get; set; } // Заглавие карточки
        [Display(Name = "Тело карточки")]
        public string Body { get; set; } // тело карточки
        [Display(Name = "Описание")]
        public string Description { get; set; } // описание карточки

        [Display(Name = "ID базы")]
        public int BaseId { get; set; }

        [Display(Name = "База данных")]
        public virtual TestBase Base { get; set; }
    }
}
