﻿
using System;
using System.ComponentModel.DataAnnotations;
namespace Maris_Sorana_Lab2.Models.LibraryViewModels
{
    public class OrderGroup
    {
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public int BookCount { get; set; }

    }
}
