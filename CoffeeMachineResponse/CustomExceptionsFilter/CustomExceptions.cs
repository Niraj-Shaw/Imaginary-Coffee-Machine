using System;

namespace CoffeeMachineResponse.CustomExceptionsFilter
{
    [Serializable]
    public class Status503Exception : Exception { }

    [Serializable]
    public class Status418Exception : Exception { }


}