using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

// Attached to hand, select an object
/**
 * User can move hand to select an object
 * And Confirm selection or Quit select mode
 * Once Confirmed, the Manipulation Panel shows up, and Confirm button turns to Reselect
**/

public class SelectHandController : MonoBehaviour
{
    public Material PreSelect = null;
    public Material OnSelect;
    //public GameObject Hand;
    //public GameObject Pointer;
    public static GameObject preObj = null;
    //private GameObject Initial = null;

    //public static string TransformType = "";
    //public static float mid;
    //public static bool comfirmed = false;
    public GameObject SelectInfoPanel;
    public GameObject ImageTarget;

    // Start is called before the first frame update
    void Start()
    {
        //Initial = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Deselect preObj
        if (!GameController.InSelectMode)
        {
            if (preObj != null)
            {
                preObj.GetComponent<Renderer>().material = PreSelect;//color return
            }
            preObj = null;
        }
        else
        {
            if (IsTrackingMarker())
            {
                SelectInfoPanel.SetActive(false);
            }
            else if (!IsTrackingMarker())
            {
                SelectInfoPanel.SetActive(true);
            }
        }

        // if quit selection mode, preObj = null, deselect select button


    }
    private void OnTriggerEnter(Collider other)
    {
        //if it is not in select mode or have already selected, no select highlight and update will be made
        if (!GameController.InSelectMode || GameController.SelectedMode) return;

        //update selected object and highlight it
        if (preObj != null)
        {
            preObj.GetComponent<Renderer>().material = PreSelect;
        }
        PreSelect = other.gameObject.GetComponent<Renderer>().material;
        other.gameObject.GetComponent<Renderer>().material = OnSelect;
        preObj = other.gameObject;
    }

    private bool IsTrackingMarker()
    {
        //var imageTarget = GameObject.Find(imageTargetName);
        var trackable = ImageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }

}
