using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteController : MonoBehaviour
{

    public void Delete(string delete)
    {
        if (delete.Equals("Delete"))
        {
            //delete the object
            List<GameObject> list = GameController.list;
            list.Remove(GameController.SelectObject);
            Destroy(GameController.SelectObject);

            //back to InSelectMode
            GameController.InSelectMode = true;
            GameController.SelectedMode = false;

            //make delete button in manipulate panel nonpressed
            ManipulateController.ObjType = "Delete";
        }
        else
        {
            ManipulateController.ObjType = "Delete";
        }
        //make current panelinvisible panel
        gameObject.transform.parent.gameObject.SetActive(false);

    }
}
