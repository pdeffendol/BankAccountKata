﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountApp
{
    public class Console : IConsole
    {
        public void WriteLine(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}
