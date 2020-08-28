using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CameraPerspective : MonoBehaviour
{
    public Scrollbar scrollbar;
    private Camera mainCam;   

   public float targetZoom =60f;
    float zoomFactor = 30f;
    float currentZoom;
    float zoomLerpSpeed = 10;
    public float speed = 10;
    float zoomIn = 10f;//=0
    float zoomOut = 60f;//=1
    public KeyControl kc;
    float scrollData;
    float campos = 0;
    public Text scale_text;
    public bool close;
    public GameObject panelSubTools;
    public static CameraPerspective pc;
    public Text_InfoOpin_Zoom ti;
    public bool called =false;
    public bool zoomingIn;
    public bool zoomingOut;
    public bool kcActive = false;
 
    void Awake() {
    
        
        pc = this;
        ti = FindObjectOfType<Text_InfoOpin_Zoom>();
        

    }

    void Start()
    {

       
    
        mainCam = Camera.main;
        if (GameObject.FindGameObjectWithTag("KeyControl")!=null)
        {

       
        }
       
    }
    public void fetchScript()
    {
        kc = GameObject.FindGameObjectWithTag("KeyControl").GetComponent<KeyControl>();

    }
    public bool UpdateZoom(bool updatedclose)
    {

        close = updatedclose;


        return close;
    }

   
    void Update() {



        scrollData = Input.GetAxis("Mouse ScrollWheel");
        if (kcActive && called ==true) {
            fetchScript();
         
            kc.scrollwheel = true;
        }
        if (close==true) {
            ti.CurrentCamProps(scrollbar.size,campos);
            called = false;
        }
        else if(zoomingIn==false&&zoomingOut==false)
        {
        
           
            targetZoom -= scrollData * zoomFactor;
            targetZoom = Mathf.Clamp(targetZoom, zoomIn, zoomOut);
            campos = mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, targetZoom, Time.deltaTime);


            scrollbar.size = 1 - (campos - zoomIn) / (zoomOut - zoomIn);

            scale_text.text = campos.ToString("F2") + " cm";
            called = true;
        }
    }

   
       //scrollbar= GetComponent("Scale") as Scrollbar;d
   
}