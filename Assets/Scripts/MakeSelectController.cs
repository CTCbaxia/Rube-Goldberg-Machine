using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeSelectController : MonoBehaviour
{
    // Change confirm button text
    public Text ButtonText;
    public static string ObjType = "";
    private void ChangeText(string text)
    {
        ButtonText.text = text;
    }
    public void MakeSelect(string type)
    {
        //print("gameObjec:"+gameObject.GetComponentInChildren());
        if(type.Equals("Quit"))
        {
            ObjType = "Quit";
        }
        else if (type.Equals(ButtonText.text))
        {
            // both are confirm
            ObjType = "Confirm";
            ChangeText("Reselect");
        }
        else
        {
            ObjType = "Reselect";
            ChangeText("Confirm");
        }
    }
}
