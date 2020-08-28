using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyControl : MonoBehaviour
{
    public GameObject camPivot;
    public Camera cam;
    public float targetZoom;
    float campos;
    float zoomIn = 10f;//=0
    float zoomOut = 60f;//=1
    public Scrollbar scrollbar;
    public Text scale_text;
    public bool zoomingIn;
    public bool zoomingOut;
    public float anglex = 30f;
   
    public Vector3 altertRotation;
    //Buttons:
    Button BzoomIn;
    CameraPerspective pc;
  Button BzoomOut;
   public static KeyControl kc;
    Button BturnLeft;
    Button BturnRight;
    Button Bstop;
    Button BbendLeft;
    Button BbendRight;
    Button BbendUp;
    Button BbendDown;
    public bool scrollwheel;

    private void Awake()
    {
        kc = this;
         pc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraPerspective>();
    }
    // Start is called before the first frame update
    void Start()
    {   
     
       
        //Buttons:
        BzoomIn =       GameObject.Find("ZoomInButton").GetComponent<Button>();
        BzoomOut =      GameObject.Find("ZoomOutButton").GetComponent<Button>();
        BturnLeft =     GameObject.Find("LinksDrButton").GetComponent<Button>();
        BturnRight =    GameObject.Find("RechtsDrButton").GetComponent<Button>();
        Bstop =         GameObject.Find("StopDrButton").GetComponent<Button>();
        BbendUp =       GameObject.Find("ObenDrButton (2)").GetComponent<Button>();
        BbendDown =    GameObject.Find("UntenDrButton").GetComponent<Button>();

        BzoomIn.onClick.AddListener(delegate { ZoomInButton(); });
        BzoomOut.onClick.AddListener(delegate { ZoomOutButton(); });
        BturnLeft.onClick.AddListener(delegate { TurnLeftButton(); });
        BturnRight.onClick.AddListener(delegate { TurnRightButton(); });
        Bstop.onClick.AddListener(delegate { StopActionButton(); });
        BbendUp.onClick.AddListener(delegate { BendUpButton(); });
        BbendDown.onClick.AddListener(delegate { BendDownButton(); });



        cam = Camera.main;
        camPivot = GameObject.FindGameObjectWithTag("CamPivot");
        scrollbar = GameObject.FindGameObjectWithTag("Zoom").GetComponent<Scrollbar>();
       
        altertRotation = new Vector3(camPivot.transform.rotation.x, camPivot.transform.rotation.y, camPivot.transform.rotation.z);
        targetZoom = cam.fieldOfView;
        scale_text = GameObject.Find("Scale_text").GetComponent<Text>();
    }
    /*  Hamburger Menü
  Zurück Button
  Exit Button
  Zoom in 
  Zoom out
  Linksdrehung
  Stop Icon(Bei den Drehungen soll sich das Objekt automatisch drehen, der Stop-Button soll zum Anhalten der Drehung dienen)
  Rechtsdrehung
  nach oben
  nach unten
  nach links
  nach rechts*/
    // Update is called once per frame
    private void OnEnable()
    {
        pc.kcActive = true;
    }
    private void OnDisable()
    {
        pc.kcActive = false;
    }
    public void Update()
       {

        if (scrollwheel == false)
        {

            pc.zoomingIn = zoomingIn;
            pc.zoomingOut = zoomingOut;
        }
        else {
    
               zoomingIn = false;
               zoomingOut = false;
                
                }
    }
    public void ZoomInButton()
    {
      
            StopAllCoroutines();

            StartCoroutine(ZoomInCoroutine());
        
        }

    public void ZoomOutButton()
    {
        zoomingIn = false;
        zoomingOut = false;
      
            StopAllCoroutines();
            StartCoroutine(ZoomOutCoroutine());
            }
        
   public  IEnumerator ZoomInCoroutine() {
        targetZoom -= 10f;
        targetZoom = Mathf.Clamp(targetZoom, zoomIn, zoomOut);
        zoomingIn = true;
        float t = 0;
        while (t < 1&&zoomingIn==true)
        {
            campos = cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetZoom, t);

           
            scrollbar.size = 1 - (campos - zoomIn) / (zoomOut - zoomIn);
            t += 0.2f * Time.deltaTime;
            scale_text.text = campos.ToString("F2") + " cm";

            yield return zoomingIn;
        }
     
       //cam.fieldOfView = campos;
        zoomingIn = false;
        pc.targetZoom = targetZoom;
    }
    
   public IEnumerator ZoomOutCoroutine() {
        targetZoom += 10f;
        targetZoom = Mathf.Clamp(targetZoom, zoomIn, zoomOut);
        zoomingOut=true;
        float t = 0;
        while (t < 1&&zoomingOut == true)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetZoom, t);
            campos = cam.fieldOfView;
            scrollbar.size = 1 - (campos - zoomIn) / (zoomOut - zoomIn);
            t += 0.2f * Time.deltaTime;
            scale_text.text = campos.ToString("F2") + " cm";

           
            yield return zoomingOut;
        }
        zoomingOut = false;
 
         cam.fieldOfView= campos;
        pc.targetZoom = targetZoom;

    }

   

    public void TurnLeftButton() {
        StopAllCoroutines();
        StartCoroutine(TurnLeftCoroutine());
    }
    public IEnumerator TurnLeftCoroutine()
    {
        
        altertRotation += new Vector3(0f, anglex, 0f);
        Quaternion quat = Quaternion.Euler(altertRotation);
        float t = 0;
        while (t < 1)
        {
         
            camPivot.transform.rotation =  Quaternion.Slerp(camPivot.transform.rotation,quat, t);
            t += 0.2f * Time.deltaTime;
            yield return null;
        }
        
    }
        public void TurnRightButton() {
        StopAllCoroutines();
        StartCoroutine(TurnRightCoroutine());

    }
    public IEnumerator TurnRightCoroutine()
    {

        altertRotation -= new Vector3(0f,anglex, 0f);
       
        Quaternion quat = Quaternion.Euler(altertRotation);
        float t = 0;
        while (t < 1)
        {

            camPivot.transform.rotation = Quaternion.Slerp(camPivot.transform.rotation, quat, Time.deltaTime);
            t += 0.2f * Time.deltaTime;
            yield return null;

        }
    }
   public void StopActionButton() {
        StopAllCoroutines();
        camPivot.transform.position = camPivot.transform.position;
    }

    public void BendUpButton()
    {
        StopAllCoroutines();
        StartCoroutine(BendUpButtonCoroutine());
    }

    IEnumerator BendUpButtonCoroutine()
    {
        
        altertRotation += new Vector3(anglex,0f, 0f);
        Quaternion quat = Quaternion.Euler(altertRotation);
        float t = 0;
        while (t < 1)
        {

            camPivot.transform.rotation = Quaternion.Slerp(camPivot.transform.rotation, quat, Time.deltaTime);
            t += 0.2f * Time.deltaTime;
            yield return null;

        }
    }
    public void BendDownButton()
    {
        StopAllCoroutines();

        StartCoroutine(BendDownButtonCoroutine());
    }

    IEnumerator BendDownButtonCoroutine()
    {
 
        altertRotation -= new Vector3(anglex,0f, 0f);
        Quaternion quat = Quaternion.Euler(altertRotation);
        float t = 0;
        while (t < 1)
        {

            camPivot.transform.rotation = Quaternion.Slerp(camPivot.transform.rotation, quat, Time.deltaTime);
            t += 0.2f * Time.deltaTime;
            yield return null;
        }
    }


}
