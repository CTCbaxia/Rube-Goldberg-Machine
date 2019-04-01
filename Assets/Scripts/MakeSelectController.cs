using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeSelectController : MonoBehaviour
{
    // Change confirm button text
    public Text ButtonText;
    public static string ObjType = "";

    void FixedUpdate()
    {
        if (gameObject.name.Equals("Confirm"))
        {
            ChangeText(GameController.ConfirmBtnText);
        }

    }
    private void ChangeText(string text)
    {
        ButtonText.text = text;
    }
    public void MakeSelect(string type)
    {
        ObjType = type;
    }
}
