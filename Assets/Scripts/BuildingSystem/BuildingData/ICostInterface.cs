using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface that requires building objects to implement a static
//cost getter
interface ICostInterface
{
    public static (List<string>, List<float>) getCost;
}
