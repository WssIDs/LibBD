using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibDB.DAL
{
    public class Card
    {
        [HiddenInput]
        public int Id { get; set; } // id автора
        [Required(ErrorMessage = "Введите Заглавие карточки")]
        [Display(Name = "Заглавие карточки")]
        public string Title { get; set; } // Заглавие карточки
        [Required(ErrorMessage = "Введите год заполнения карточки")]
        [Display(Name = "Год")]
        public int Year { get; set; } // Год заполнения карточки
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } // Фамилия автора (в роли категории)
        [Display(Name = "Имя")]
        public string FirstName { get; set; } // Имя автора (в роли категории)
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; } // Отчество автора (в роли категории)
        [Display(Name = "Автор (Соавторы)")]
        public string Collaborators { get; set; } // соавторы
        [Display(Name = "Тело карточки")]
        public string Body { get; set; } // тело карточки
        [Display(Name = "Описание")]
        public string Description { get; set; } // описание карточки
    }
}
