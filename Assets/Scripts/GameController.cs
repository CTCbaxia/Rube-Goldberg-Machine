using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static List<GameObject> list;

    //GameObject
    public GameObject World;
    public GameObject Sphere;
    public GameObject Board;
    public GameObject Windmill;
    public GameObject CorStair;
    public GameObject CreatePanel;
    public GameObject SelectInfoPanel;
    public GameObject SelectPanel;
    public GameObject ManipulatePanel;
    public GameObject DeleteConfirmPanel;
    //public GameObject ScaleToolbar;// image trigger
    private GameObject SelectToolbar;// image trigger
    public GameObject HandToolbar;
    public GameObject PointerToolbar;
    public GameObject Hand;
    public static GameObject SelectObject;

    //Button
    public Button CreateButton;
    public Button SelectButton;
    public Button PlayButton;
    public Button RestartButton;
    public Button TranslateButton;
    public Button RotateButton;
    public Button ScaleButton;
    public Button DeleteButton;

    private Transform initial;
    private Vector3 InitialScale;
    private Vector3 InitialPosition;
    private Vector3 InitialRotation;

    //bool
    public static bool InSelectMode;
    public static bool SelectedMode;
    public static string ConfirmBtnText;

    public bool InDeleteMode;
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
            print("MakeSelectController:" + SelectObject);
            MakeSelect(MakeSelectController.ObjType);
            MakeSelectController.ObjType = "";
        }
        if (!ManipulateController.ObjType.Equals(""))
        {
            Manipulate(ManipulateController.ObjType);
            ManipulateController.ObjType = "";
        }

        // Select Mode



        // For all kinds of selection
        if (InSelectMode)
        {
            if (SelectModeController.ObjType.Equals("Hand"))
            {
                SelectObject = SelectHandController.preObj;
                SelectToolbar = HandToolbar;
            }
            else if (SelectModeController.ObjType.Equals("Pointer"))
            {
                SelectObject = SelectPointerController.preObj;
                SelectToolbar = PointerToolbar;
            }

            //for panel visibility
            SelectMode(InSelectMode);
            ManiMode(SelectedMode);

            if (!SelectedMode) ConfirmBtnText = "Confirm";
            else ConfirmBtnText = "Reselect";
        }
        else
        {
            SelectMode(InSelectMode);
            ManiMode(SelectedMode);
        }
        // if in the manipulation mode
        if (SelectedMode)
        {
            //button update
            IsButtonPressed(DeleteButton, InDeleteMode);
            IsButtonPressed(ScaleButton, InScaleMode);
            IsButtonPressed(RotateButton, InRotateMode);
            IsButtonPressed(TranslateButton, InTranslateMode);

            if (SelectObject != null)
            {
                Manipulate();
            }
        }
        //if (SelectObject != null && SelectedMode) Manipulate();

    }

    // Control menu selection and ui visibility
    public void MenuSelect(string type)
    {
        if (type.Equals("Create"))
        {
            InSelectMode = false;
            SelectedMode = false;
            CreateMode(true);
            //SelectMode(InSelectMode);
        }
        else if (type.Equals("Select"))
        {
            InSelectMode = true;
            SelectedMode = false;
            CreateMode(false);
            //SelectMode(InSelectMode);
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
            InSelectMode = true;
            SelectedMode = true;

            //record the current transform of the selected object
            initial = SelectObject.transform;
            UpdateObj();
            //print(InitialScale);

            //initialize button value
            InDeleteMode = false;
            InScaleMode = false;
            InRotateMode = false;
            InTranslateMode = false;
        }
        else if (type.Equals("Reselect")) 
        {
            InSelectMode = true;
            SelectedMode = false;
        }
        else if (type.Equals("Quit"))
        {
            InSelectMode = false;
            SelectedMode = false;

            SelectMode(false);
        }
        //ManiMode(SelectedMode);
    }

    // Select - Confirm - Manipulate Control
    public void Manipulate(string type)
    {
        UpdateObj();

        if (type.Equals("Delete"))
        {
            if (InDeleteMode)
            {
                InDeleteMode = false;
                //IsButtonPressed(DeleteButton, false);
            }
            else
            {
                InDeleteMode = true;
                InScaleMode = false;
                InRotateMode = false;
                InTranslateMode = false;

                DeleteConfirmPanel.SetActive(true);
                //IsButtonPressed(DeleteButton, true);
                //IsButtonPressed(ScaleButton, false);
                //IsButtonPressed(RotateButton, false);
                //IsButtonPressed(TranslateButton, false);
            }

        }
        else if (type.Equals("Scale"))
        {
            if (InScaleMode)
            {
                InScaleMode = false;
                //IsButtonPressed(ScaleButton, false);
            }
            else
            {
                InDeleteMode = false;
                InScaleMode = true;
                InRotateMode = false;
                InTranslateMode = false;

                //IsButtonPressed(DeleteButton, false);
                //IsButtonPressed(ScaleButton, true);
                //IsButtonPressed(RotateButton, false);
                //IsButtonPressed(TranslateButton, false);
            }

        }
        else if (type.Equals("Rotate"))
        {
            InScaleMode = false;
            if (InRotateMode)
            {
                // deselect button
                InRotateMode = false;

                //IsButtonPressed(RotateButton, false);
            }
            else
            {
                // select button
                InDeleteMode = false;
                InScaleMode = false;
                InRotateMode = true;

                //IsButtonPressed(DeleteButton, false);
                //IsButtonPressed(ScaleButton, false);
                //IsButtonPressed(RotateButton, true);
            }

        }
        else if (type.Equals("Translate"))
        {
            InScaleMode = false;
            if (InTranslateMode)
            {
                InTranslateMode = false;
                //IsButtonPressed(TranslateButton, false);
            }
            else
            {
                InDeleteMode = false;
                InScaleMode = false;
                InTranslateMode = true;

                //IsButtonPressed(DeleteButton, false);
                //IsButtonPressed(ScaleButton, false);
                //IsButtonPressed(TranslateButton, true);
            }

        }

    }

    //---- Manipulate Function
    private void Manipulate()
    {
        //manipulation
        if (InScaleMode)
        {
            GameObject CurValue = SelectToolbar.transform.root.gameObject;
            float vlaue = CurValue.transform.position.x;
            //change scale
            SelectObject.transform.localScale = InitialScale + new Vector3(vlaue, vlaue, vlaue);

            //maintain translate and rotation
            SelectObject.transform.position = InitialPosition;
            SelectObject.transform.rotation = Quaternion.Euler(InitialRotation);

        }
        else if (InTranslateMode && !InRotateMode)
        {
            SelectObject.transform.localScale = InitialScale;
            SelectObject.transform.rotation = Quaternion.Euler(InitialRotation);
        }
        else if (InRotateMode && !InTranslateMode)
        {
            SelectObject.transform.localScale = InitialScale;
            SelectObject.transform.position = InitialPosition;
        }
        else if (InTranslateMode && InRotateMode)
        {

        }
        else if (SelectedMode && !InTranslateMode && !InRotateMode && !InScaleMode)
        {
            //SelectObject.transform.localScale = InitialScale;
            SelectObject.transform.position = InitialPosition;
            SelectObject.transform.rotation = Quaternion.Euler(InitialRotation);
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

    private void SelectMode(bool InSelectMode)
    {
        if (InSelectMode)
        {
            if (!SelectedMode)
            {
                SelectInfoPanel.SetActive(true);
            }
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

    //---- Manipulation Mode
    private void ManiMode(bool isManuMode)
    {
        if (isManuMode)
        {
            ManipulatePanel.SetActive(true);
            ManipulateController.ObjType = "";
            Hand.GetComponent<Collider>().isTrigger = false;

            //transfer the selected object to Hand
            if(SelectObject != null){
                SelectObject.transform.parent = SelectToolbar.transform;
            }

        }
        else
        {
            ManipulatePanel.SetActive(false);
            DeleteConfirmPanel.SetActive(false);

            ManipulateController.ObjType = "";
            Hand.GetComponent<Collider>().isTrigger = true;


            //transfer the selected object back to World
            if (SelectObject != null)
            {
                SelectObject.transform.parent = World.transform;
            }
        }
    }


    //---- Button Feedback
    private void IsButtonPressed(Button btn, bool isSelect)
    {
        if (isSelect)
        {
            ColorBlock cb = btn.colors;
            cb.normalColor = Color.yellow;
            cb.highlightedColor = Color.yellow;
            btn.colors = cb;
        }
        else
        {
            ColorBlock cb = btn.colors;
            cb.normalColor = Color.black;
            cb.highlightedColor = Color.black;
            btn.colors = cb;
        }
    }

    //---- Update Object Attributes
    private void UpdateObj()
    {
        InitialScale = initial.localScale;
        InitialRotation = initial.rotation.eulerAngles;
        InitialPosition = initial.position;
    }
}
