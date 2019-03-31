using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static List<GameObject> list;
    public GameObject World;
    public GameObject Sphere;
    public GameObject Board;
    public GameObject Windmill;
    public GameObject CorStair;
    public GameObject CreatePanel;
    public GameObject SelectInfoPanel;
    public GameObject SelectPanel;
    public GameObject ManipulatePanel;
    public GameObject ScaleToolbar;// image trigger
    public Button CreateButton;
    public Button SelectButton;
    public Button PlayButton;
    public Button RestartButton;
    //public Button SConfirmButton;
    //public Button SQuitButton;
    private Vector3 Initial;
    private bool InScaleMode;


    // Start is called before the first frame update
    void Start()
    {
        list = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuController.ObjType.Equals(""))
        {
            MenuSelect(MenuController.ObjType);
            MenuController.ObjType = "";
        }
        if (!CreateController.ObjType.Equals(""))
        {
            CreateObject(CreateController.ObjType);
            CreateController.ObjType = "";
        }
        if (!MakeSelectController.ObjType.Equals(""))
        {
            MakeSelect(MakeSelectController.ObjType);
            MakeSelectController.ObjType = "";
        }
        if (!ManipulateController.ObjType.Equals(""))
        {
            Manipulate(ManipulateController.ObjType);
            ManipulateController.ObjType = "";
        }
        if (InScaleMode)
        {
            print("SelectController.preObj.transform.localScale"+ SelectController.preObj.transform.localScale);
            GameObject Current = ScaleToolbar.transform.root.gameObject;
            float CurPoint = Current.transform.position.x;
            SelectController.preObj.transform.localScale = Initial + new Vector3(CurPoint, CurPoint, CurPoint);
        }
    }

    // Create the corresponding object selecting by the user
    public void CreateObject(string type)
    {
        GameObject obj = null;
        if (type.Equals("Sphere"))
        {
            obj = Instantiate(Sphere, World.transform, false);
        }
        else if (type.Equals("Board"))
        {
            obj = Instantiate(Board, World.transform, false);
        }
        else if (type.Equals("Windmill"))
        {
            obj = Instantiate(Windmill, World.transform, false);
        }
        else if (type.Equals("CorStair"))
        {
            obj = Instantiate(CorStair, World.transform, false);
        }
        list.Add(obj);
        CreateMode(false);
    }
    // Control menu selection and ui visibility
    public void MenuSelect(string type)
    {
        if (type.Equals("Create"))
        {
            CreateMode(true);
            SelectMode(false);
        }
        else if (type.Equals("Select"))
        {
            CreateMode(false);
            SelectMode(true);
        }
        else if (type.Equals("Play"))
        {
        }
        else if (type.Equals("Restart"))
        {
        }
    }

    public void MakeSelect(string type)
    {
        // show panel
        if (type.Equals("Confirm"))
        {
            ManipulatePanel.SetActive(true);
            // TODO: add selected obj to toolbar
            // TODO: add now touching other obj will not get highligted
        }
        else if (type.Equals("Reselect")) {
            // TODO: allow user to select again
            ManipulatePanel.SetActive(false);
            ManipulateController.ObjType = "";
        }
        else if (type.Equals("Quit"))
        {
            print("here click quit");
            SelectMode(false);
            ManipulateController.ObjType = "";
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
            print("Initial:"+Initial);
            //ObjType = type;
            InScaleMode = true;
        }
        else if (type.Equals("Rotate"))
        {

        }
        else if (type.Equals("Translate"))
        {

        }

    }




    // helper function
    private void CreateMode(bool inCreateMode)
    {
        if (inCreateMode)
        {
            CreatePanel.SetActive(true);
            CreateButton.interactable = false;
        }
        else
        {
            CreatePanel.SetActive(false);
            CreateButton.interactable = true;
        }
    }

    private void SelectMode(bool inSelectMode)
    {
        if (inSelectMode)
        {
            SelectInfoPanel.SetActive(true);
            SelectPanel.SetActive(true);
            SelectButton.interactable = false;
        }
        else
        {
            SelectInfoPanel.SetActive(false);
            SelectPanel.SetActive(false);
            SelectButton.interactable = true;

        }
    }
}
