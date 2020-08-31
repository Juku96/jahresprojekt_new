using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Text_InfoOpin_Zoom : MonoBehaviour
{
    public Text textInfo;
    public Text placeholder;
    public GameObject Panel;
    public PlayerControls controls;
    public Text_InfoOpin_Zoom ti;
    public Sprite sprite;
    public GameObject clicked;
    public Camera mainCam;
    public float zoomFactor =5f;
    float offset = 3f;
    public GameObject CamPivot;
    public Vector3 distance;
    public Vector3 defaultPosCam;
    public Quaternion defaultRotCam;
    public float startTime;
    public float journeyLength;
    public Vector3 defaultPosPivot;
    public bool close = false;
    public float voF;
    public Scrollbar scrollbar;
    public bool zooming = false;
    public CameraPerspective cp;
    private Vector3 defPivotRot;
    float defcamPivotAbs;
    

    void Awake()
    {
      
         cp= FindObjectOfType<CameraPerspective>();
        controls = new PlayerControls();
     
     
     
            controls.MouseControl.Button.performed += ctx => GetText();
        
    }// Start is called before the first frame update
    public void Start()
    {
        
        Panel = GameObject.FindGameObjectWithTag("panel_Placeholder");
        Panel.SetActive(false);
      
        CamPivot = GameObject.FindWithTag("CamPivot");
   
        defaultPosCam = mainCam.transform.position;
        scrollbar = GameObject.FindGameObjectWithTag("Zoom").GetComponent<Scrollbar>();
        defaultRotCam = mainCam.transform.localRotation;
    
        startTime = Time.time;
        defaultPosPivot = CamPivot.transform.position;
        defcamPivotAbs = Vector3.Distance(defaultPosCam, defaultPosPivot);



        ti = this;
    }
    public void CurrentCamProps( float currentscrollbar, float currentfieldofView)
    { scrollbar.size = currentscrollbar;
      voF = currentfieldofView;

    }
    public void GetText()
    {
        if (mainCam != null)
        {
            if (close == false)
            {


                RaycastHit hit;
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 50) && hit.collider.gameObject.CompareTag("Sprite"))
                {

                    clicked = hit.collider.gameObject;
                    journeyLength = Vector3.Distance(defaultPosCam, clicked.transform.position);
                    StopAllCoroutines();
                    StartCoroutine(CameraClose(clicked));
                }
            }
            else if (close == true)
            {
                StopAllCoroutines();
                StartCoroutine(CameraDefault());
            }

        }
    }
     IEnumerator CameraClose(GameObject clicked) {

       
        float t = 0;
        close = true;
        cp.UpdateZoom(close);
        Panel.SetActive(true);
        textInfo = clicked.GetComponentInChildren<Text>();

        placeholder.text = textInfo.text;
        
        clicked.SetActive(false);
        while (t <1)
        {
           

            CamPivot.transform.position= Vector3.Lerp(CamPivot.transform.position, clicked.transform.position, t);
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position,clicked.transform.position+clicked.transform.forward * -offset,t);

            mainCam.transform.rotation = Quaternion.Lerp(mainCam.transform.rotation,clicked.transform.rotation,t);
            mainCam.fieldOfView =  Mathf.Lerp(mainCam.fieldOfView, 60f,t);
            scrollbar.size = 1 - (mainCam.fieldOfView - 10f) / (60f - 10f);
           
            t += 0.5f * Time.deltaTime;
            zooming = true;
   
     
            yield return close;
        }

        CamPivot.transform.position = clicked.transform.position;
        mainCam.transform.position = clicked.transform.position + clicked.transform.forward * -offset;
        mainCam.transform.rotation = clicked.transform.rotation;
        mainCam.fieldOfView = 60f;
        zooming = false;
        yield return close;
    }
    IEnumerator CameraDefault()
    {
       
        float t = 0;
        close = false;


     
      

        Vector3 localPos= new Vector3(0f,0f,-14.6f);
        Panel.SetActive(false);
    
        clicked.SetActive(true);
        
        while (t<1) {
           
            
            
         
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView,voF, t);
            scrollbar.size = 1 - (mainCam.fieldOfView - 10f) / (60f - 10f);
            mainCam.transform.localPosition = Vector3.Lerp(mainCam.transform.localPosition,localPos, t);
            mainCam.transform.localRotation = Quaternion.Slerp(mainCam.transform.localRotation, defaultRotCam,t);
            CamPivot.transform.position = Vector3.Lerp(CamPivot.transform.position,defaultPosPivot, t);

            t += 0.5f * Time.deltaTime;

            zooming = true;
            yield return null;
        }
        CamPivot.transform.position = defaultPosPivot;
        mainCam.transform.localPosition = localPos;
        mainCam.transform.localRotation = defaultRotCam;
        mainCam.fieldOfView = voF;
       

        cp.UpdateZoom(close);
        zooming = false;
        yield return null;
    }
   public void InfoMenuClicked( GameObject Infopoints){
      StartCoroutine(CameraClose(Infopoints));
       
        clicked = Infopoints;
       
    
  
    }


    public void OnEnable()
    {
        controls.MouseControl.Enable();
    } 
}
 