using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();

    }
}
// указываю какие  методы должны быть определены. те если в классе реализуется интерфейс, то в нем реализуются эти методы.