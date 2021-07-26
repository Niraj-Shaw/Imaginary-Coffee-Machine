using System;
using System.Collections.Generic;
using System.Text;
using CoffeeMachineResponse.Models;

namespace CoffeeMachineResponse.Interfaces
{
    public interface ICoffeeMachine
    {
        public MachineResponse GetResponse(int RequestCount);
    }
}
