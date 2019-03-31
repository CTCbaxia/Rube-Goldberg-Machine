using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : MonoBehaviour
{
    // pass ObjType that the user want to create to GameController
    public static string ObjType = "";
    public void CreateObject(string type)
    {
        ObjType = type;
    }
}
