﻿using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolIca.Geographie;

namespace CentreDeVaccination.Models
{
    public class Adresse : AdresseBE, IAdresse
    {
        public int Id { get; set; }
    }
}
