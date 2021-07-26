using CoffeeMachineResponse.Interfaces;
using CoffeeMachineResponse.Models;
using CoffeeMachineResponse.CustomExceptionsFilter;
using System;

namespace CoffeeMachineResponse.Repositories
{
    public class CoffeeMachine : ICoffeeMachine
    {
     
        public MachineResponse GetResponse(int RequestCount)
        {
            MachineResponse MachineResponse = null; 
         
            if (RequestCount % 5 == 0)
            {   
                throw new Status503Exception();
            }
            else if (DateTime.Now.Day == 1 && DateTime.Now.Month == 4)
            {
                throw new Status418Exception();           
            }
            else
            {
                MachineResponse = new MachineResponse();
                MachineResponse.Message = "Your piping hot coffee is ready";
                MachineResponse.Prepared = DateTime.Now;
            }
            return MachineResponse;
        }

    }
}
