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

public class SelectController : MonoBehaviour
{
    public Material PreSelect = null;
    public Material OnSelect;
    public GameObject Hand;
    public static GameObject preObj = null;
    private GameObject Initial = null;

    public static string TransformType = "";
    public static float mid;
    public static bool comfirmed = false;
    //public GameObject ConfirmPanel;
    //public GameObject ManipulatePanel;
    public GameObject SelectInfoPanel;
    public GameObject ImageTarget;

    // Start is called before the first frame update
    void Start()
    {
        Initial = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if(preObj != null)
        {
            // show confirm selection
        }
        // if quit selection mode, preObj = null, deselect select button

        if (GameController.InSelectMode && IsTrackingMarker())
        {
            SelectInfoPanel.SetActive(false);
        }
        else if(GameController.InSelectMode && !IsTrackingMarker())
        {
            SelectInfoPanel.SetActive(true);
            //print("Warning.....Losing hand");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!GameController.InSelectMode) return;//if it is not in select mode, no select highlight will be made

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
