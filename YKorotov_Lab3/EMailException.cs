﻿using System;
namespace YKorotov_Lab3
{
    class EMailException : Exception
    {
        private string _msg;

        public EMailException(string msg)
        {
            _msg = msg;
        }

        public override string Message
        {
            get => _msg;
        }
    }
}
