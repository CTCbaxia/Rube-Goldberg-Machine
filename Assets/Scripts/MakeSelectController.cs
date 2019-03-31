using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeSelectController : MonoBehaviour
{
    // Change confirm button text
    public Text ButtonText;
    public static string ObjType = "";
    public void ChangeText()
    {
        if (SelectController.comfirmed)
        {
            ButtonText.text = "ReSelect";
        }
        else
        {
            ButtonText.text = "Confirm Selection";
        }
    }
    public void MakeSelect(string type)
    {
        ObjType = type;
    }
}
