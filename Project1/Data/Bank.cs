using System;
using System.Collections.Generic;

namespace Project1.Data
{
    public class Bank<T>
    {
        public List<T> Datas { get; set; }
        public Bank()
        {
            Datas=new List<T>();
        }
    }
}
