using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : MonoBehaviour
{
    public static string ObjType = "";
    public void CreateObject(string type)
    {
        ObjType = type;
    }
}
