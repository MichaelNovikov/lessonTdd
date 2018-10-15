﻿using System;
namespace lessonTdd.Coonverter
{
    public class ConvertException : Exception
    {
        public ConvertException()
        {
        }

        public ConvertException(string message) : base(message)
        {
        }

        public ConvertException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
