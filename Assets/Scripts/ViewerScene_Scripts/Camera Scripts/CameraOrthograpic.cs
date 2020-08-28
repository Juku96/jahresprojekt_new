using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CameraOrthograpic : MonoBehaviour
{
    public Scrollbar scrollbar;
    private Camera cam;
    float targetZoom;
    float zoomFactor = 3f;
    float currentZoom;
    float zoomLerpSpeed = 10;
    public float speed = 10;
    float zoomIn = 0.5f;//=0
    float zoomOut = 5f;//=1
    float scrollData;
    float campos = 0;
    public Text scale_text;
    
    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main;
        targetZoom = cam.orthographicSize;

    }
        // Update is called once per frame
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                Debug.Log("Application quit");
            }

            scrollData = Input.GetAxis("Mouse ScrollWheel");
            targetZoom -= scrollData * zoomFactor;
            targetZoom = Mathf.Clamp(targetZoom, zoomIn, zoomOut);
            campos = cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime);
        if (Mathf.Abs(campos - targetZoom) < 1)
        {
            scrollbar.size = 1 - (campos - zoomIn) / (zoomOut - zoomIn);

            scale_text.text = campos.ToString("F2") + " cm";
        }
        }

}
