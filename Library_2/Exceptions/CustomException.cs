﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_2.Exceptions
{
    class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }

        public CustomException()
        {

        }
    }
}
