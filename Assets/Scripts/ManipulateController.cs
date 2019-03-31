using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to each button in Manipulation Panel
// TODO: 要移到 Game Controller 里面
public class ManipulateController : MonoBehaviour
{
    public static string ObjType = "";
    private void Manipulate(string type)
    {
        ObjType = type;
    }

}
