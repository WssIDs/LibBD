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
        [Required(ErrorMessage = "Введите Заглавие карточки")]
        [Display(Name = "Заглавие карточки")]
        public string Title { get; set; } // Заглавие карточки
        [Required(ErrorMessage = "Введите год заполнения карточки")]
        [Display(Name = "Год")]
        public int Year { get; set; } // Год заполнения карточки

        public int? AuthId { get; set; }
        public TestAuth Auth { get; set; }
    }
}
