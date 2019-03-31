using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

// Attached to hand
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
    public GameObject ConfirmPanel;
    public GameObject ManipulatePanel;


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

    }
    private void OnTriggerEnter(Collider other)
    {
        if (preObj != null)
        {
            preObj.GetComponent<Renderer>().material = PreSelect;
        }
        PreSelect = other.gameObject.GetComponent<Renderer>().material;
        other.gameObject.GetComponent<Renderer>().material = OnSelect;
        preObj = other.gameObject;
        //print("collider:"+other.gameObject.name);
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    other.gameObject.GetComponent<Renderer>().material = PreSelect;
    //}

}
