using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to each button in Manipulation Panel
public class ManipulateController : MonoBehaviour
{

    public GameObject Toolbar;// image trigger
    private string ManiType = "";
    private Vector3 Initial; 

    void Update()
    {
        if (ManiType.Equals("Scale"))
        {
            GameObject Current = Toolbar.transform.root.gameObject;
            float CurPoint = Current.transform.position.x;
            SelectController.preObj.transform.localScale = Initial + new Vector3(CurPoint, CurPoint, CurPoint);
        }
    }

    public void Manipulate(string type)
    {
        if (type.Equals("Delete"))
        {
            Destroy(SelectController.preObj);//remove from select point?
        }
        else if (type.Equals("Scale"))
        {
            Initial = SelectController.preObj.transform.localScale;
            ManiType = type;
        }
        else if (type.Equals("Rotate"))
        {

        }
        else if (type.Equals("Translate"))
        {

        }

    }
}
