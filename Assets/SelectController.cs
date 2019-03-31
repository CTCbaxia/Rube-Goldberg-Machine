using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    public Material PreSelect = null;
    public Material OnSelect;
    public GameObject Hand;
    private GameObject preObj = null;
    private GameObject Initial = null;
    private float min;
    private float max;
    public static bool confirmed = false;
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
        min = Math.Min(min, Hand.transform.position.x);
        max = Math.Max(max, Hand.transform.position.x);
        print(max - min);

        //print(gameObject.transform.position.x + " " + gameObject.transform.position.y+ " " + gameObject.transform.position.z);
        if(preObj != null)
        {
            GameObject Current = transform.root.gameObject;
            float value = Current.transform.position.x - Initial.transform.position.x;
            print("value:" + value);
            preObj.transform.localScale += new Vector3(value * 5, 0, 0);

            // show confirm selection
            ConfirmPanel.SetActive(true);

        }

        if (confirmed)
        {
            ConfirmPanel.SetActive(false);
            ManipulatePanel.SetActive(true);
        }
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
        print("collider:"+other.gameObject.name);
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    other.gameObject.GetComponent<Renderer>().material = PreSelect;
    //}
}
