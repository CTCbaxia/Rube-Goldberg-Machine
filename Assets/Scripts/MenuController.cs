using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static string ObjType = "";
    public void MenuSelect(string type)
    {
        ObjType = type;
    }
}
