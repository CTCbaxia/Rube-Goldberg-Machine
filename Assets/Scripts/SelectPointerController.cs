﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SelectPointerController : MonoBehaviour
{
    public Material PreSelect = null;
    public Material OnSelect;
    public GameObject SelectInfoPanel;
    public GameObject ImageTarget;
    public static GameObject preObj = null;
    private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
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

            //if it is not in select mode or have already selected, no select highlight and update will be made
            if (GameController.SelectedMode) return;

            //cast a ray
            lr.startWidth = 0.002f;
            lr.endWidth = 0.002f;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.forward * 20 + transform.position);

            // update selected object
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.transform.gameObject.CompareTag("Plane"))
                {
                    return;
                }
                else
                {
                    GameObject curObj = hit.transform.gameObject;

                    if (preObj != null)
                    {
                        preObj.GetComponent<Renderer>().material = PreSelect;
                    }
                    PreSelect = curObj.GetComponent<Renderer>().material;
                    curObj.GetComponent<Renderer>().material = OnSelect;
                    preObj = curObj;
                }
            }
        }

    }
    private bool IsTrackingMarker()
    {
        //var imageTarget = GameObject.Find(imageTargetName);
        var trackable = ImageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }

}
