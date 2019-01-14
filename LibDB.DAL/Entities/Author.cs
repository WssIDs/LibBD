using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibDB.DAL
{
    public class Author
    {
        [HiddenInput]
        public int AuthorId { get; set; } // id автора
        [Required(ErrorMessage = "Введите Заглавие карточки")]
        [Display(Name = "Заглавие карточки")]
        public string CardTitle { get; set; } // Заглавие карточки
        [Required(ErrorMessage = "Введите год заполнения карточки")]
        [Display(Name = "Год заполнения карточки")]
        public int CardYear { get; set; } // Год заполнения карточки
        [Required(ErrorMessage = "Введите фамилию автора")]
        [Display(Name = "Фамилия автора")]
        public string LastName { get; set; } // Фамилия автора (в роли категории)
        [Required(ErrorMessage = "Введите имя автора")]
        [Display(Name = "Имя автора")]
        public string FirstName { get; set; } // Имя автора (в роли категории)
        //[Required(ErrorMessage = "Введите соавторов")]
        [Display(Name = "Соавторы")]
        public string Collaborators { get; set; } // Соавторы
        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название")]
        public string Title { get; set; } // Название журнала, книги, статьи
        [Required(ErrorMessage = "Введите год выпуска")]
        [Display(Name = "Год выпуска")]
        public int Year { get; set; } // год выпуска журнала, книги, статьи
        [Required(ErrorMessage = "Введите номер")]
        [Display(Name = "Номер")]
        public int Number { get; set; } // номер журнала, книги, статьи
        [Required(ErrorMessage = "Введите страницы")]
        [Display(Name = "Страницы")]
        public string Pages { get; set; } // страницы журнала, книги, статьи
        [Required(ErrorMessage = "Введите описание карточки")]
        [Display(Name = "Описание")]
        public string Description { get; set; } // описание карточки
    }
}
