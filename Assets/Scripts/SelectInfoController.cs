using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SelectInfoController : MonoBehaviour
{
    public GameObject ImageTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrackingMarker())
        {
            gameObject.SetActive(false);
        }
    }
    private bool isTrackingMarker()
    {
        //var imageTarget = GameObject.Find(imageTargetName);
        var trackable = ImageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }
}
