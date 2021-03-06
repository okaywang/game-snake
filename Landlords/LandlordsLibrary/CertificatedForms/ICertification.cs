﻿using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public interface ICertification
    {
        IFormation Parse(List<Card> cards);
        bool IsValid(List<Card> cards);
    }
}
