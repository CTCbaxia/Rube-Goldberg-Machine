using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteController : MonoBehaviour
{

    public void Delete()
    {
        //delete the object
        List<GameObject> list = GameController.list;
        list.Remove(SelectController.preObj);
        Destroy(SelectController.preObj);

        //invisible panel
        gameObject.transform.parent.gameObject.SetActive(false);

        //back to InSelectMode
        GameController.InSelectMode = true;
        GameController.SelectedMode = false;

    }
}
