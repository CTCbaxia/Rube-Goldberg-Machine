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
    //public GameObject ScaleToolbar;// image trigger
    public GameObject SelectToolbar;// image trigger
    public Button CreateButton;
    public Button SelectButton;
    public Button PlayButton;
    public Button RestartButton;
    public static bool InSelectMode;
    //public Button SConfirmButton;
    //public Button SQuitButton;
    private Transform initial;
    private Vector3 InitialScale;
    private Vector3 InitialPosition;
    private Vector3 InitialRotation;
    private bool InScaleMode;
    private bool InTranslateMode;
    private bool InRotateMode;


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
            GameObject CurValue = SelectToolbar.transform.root.gameObject;
            float vlaue = CurValue.transform.position.x;
            //change scale
            SelectController.preObj.transform.localScale = InitialScale + new Vector3(vlaue, vlaue, vlaue);

            //maintain translate and rotation
            SelectController.preObj.transform.position = InitialPosition;
            SelectController.preObj.transform.rotation = Quaternion.Euler(InitialRotation);

        }
        if (InTranslateMode)
        {

        }
        if (InRotateMode)
        {

        }
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
            InSelectMode = true;
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
            print("Create!!!!!!!!!");
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

    public void MakeSelect(string type)
    {
        // show panel
        if (type.Equals("Confirm"))
        {
            ManipulatePanel.SetActive(true);
            InSelectMode = false; //now touching other obj will not get highligte

            //record the current transform of the selected object
            initial = SelectController.preObj.transform;

            //transfer the selected object to SelectToolbar
            SelectController.preObj.transform.parent = SelectToolbar.transform;
        }
        else if (type.Equals("Reselect")) {
            InSelectMode = true;
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

    // Select - Confirm - Manipulate Button Control
    public void Manipulate(string type)
    {
        if (type.Equals("Delete"))
        {
            Destroy(SelectController.preObj);//remove from select point?
        }
        else if (type.Equals("Scale"))
        {
            //Initial = SelectController.preObj.transform.localScale;
            InitialScale = initial.localScale;//get current scale
            InitialRotation = initial.rotation.eulerAngles;
            InitialPosition = initial.position;

            InScaleMode = true;
            InRotateMode = false;
            InTranslateMode = false;
        }
        else if (type.Equals("Rotate"))
        {
            InRotateMode = true;
        }
        else if (type.Equals("Translate"))
        {
            InTranslateMode = true;
        }

    }




    //---- helper function for Menu Button Control, START
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
    //---- helper function for Menu Button Control, END
}
