﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        void TInsert(Writer writer, string password);
        void TUpdate(Writer writer, string password);
        bool IsWriterControl(string mail);
    }
}
