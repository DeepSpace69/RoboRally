﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
   public class Register:IRegister
    {
       public Register(int id)
       {
           this.ID = id;
       }

       public int ID { get; set; }

       public IOrderCard Content { get; set; }

       public bool IsAvailable { get; set; }
    }
}