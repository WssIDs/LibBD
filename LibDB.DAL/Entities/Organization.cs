using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibDB.DAL
{
    public class Organization
    {
        [HiddenInput]
        public int OrganizationId { get; set; } // id профиля организации
        [Required(ErrorMessage = "Введите полное наименование организации")]
        [Display(Name = "Полное наименование организации")]
        public string FullOrganizationName { get; set; } // Полное наименование организации
        [Required(ErrorMessage = "Введите сокращенное наименование организации")]
        [Display(Name = "Сокращенное наименование организации")]
        public string ShortOrganizationName { get; set; } // Сокращенное наименование организации
        [Required(ErrorMessage = "Введите ФИО директора")]
        [Display(Name = "ФИО директора")]
        public string Director { get; set; } // ФИО директора
        [Required(ErrorMessage = "Введите номер телефона")]
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } // номер телефон
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [Display(Name = "Электронная почта")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Неверный адрес электронной почты")]
        public string Email { get; set; } // email
    }
}
