using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectModeController : MonoBehaviour
{
    public static string ObjType;
    public void SelectMode(string type)
    {
        ObjType = type;
    }
}
