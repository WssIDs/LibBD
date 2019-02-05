using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibDB.DAL
{
    public class TestBase
    {
        [HiddenInput]
        public int Id { get; set; } // id бд
        [Required(ErrorMessage = "Введите Заглавие")]
        [Display(Name = "Заглавие")]
        public string Title { get; set; } // Заглавие
        [Display(Name = "Описание")]
        public string Description { get; set; } // Описание

        public virtual IEnumerable<TestCard> Cards { get; set; }
    }
}
