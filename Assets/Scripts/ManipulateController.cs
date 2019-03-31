using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to each button in Manipulation Panel
// TODO: 要移到 Game Controller 里面
public class ManipulateController : MonoBehaviour
{


    public static string ObjType = "";
    //private Vector3 Initial; 

    void Update()
    {
        //if (ObjType.Equals("Scale"))
        //{
        //    GameObject Current = Toolbar.transform.root.gameObject;
        //    float CurPoint = Current.transform.position.x;
        //    SelectController.preObj.transform.localScale = Initial + new Vector3(CurPoint, CurPoint, CurPoint);
        //}
    }
    private void Manipulate(string type)
    {
        ObjType = type;
    }
    //public void Manipulate(string type)
    //{
    //    if (type.Equals("Delete"))
    //    {
    //        Destroy(SelectController.preObj);//remove from select point?
    //    }
    //    else if (type.Equals("Scale"))
    //    {
    //        Initial = SelectController.preObj.transform.localScale;
    //        ObjType = type;
    //    }
    //    else if (type.Equals("Rotate"))
    //    {

    //    }
    //    else if (type.Equals("Translate"))
    //    {

    //    }

    //}
}
