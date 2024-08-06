﻿using System.ComponentModel.DataAnnotations;

namespace ManagementPerson.Api.ViewModels
{
    public class StudentCreateUpdateViewModel : PersonCreateViewModel
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "StudentNumber must be exactly 5 digits.")]
        public string StudentNumber { get; set; }

        [Required]
        [Range(0, 10)]
        public double AvengerMark { get; set; }
    }
}