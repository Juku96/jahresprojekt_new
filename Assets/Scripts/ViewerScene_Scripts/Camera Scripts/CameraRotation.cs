using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class CameraRotation : MonoBehaviour
{

    Vector3 previousPosition;
    
    bool left = false;
    bool right = false;
 
    float t = 3;
    float moveSpeed = 100.0f;
    public float rotInput = 10;
    public bool once = false;
   


    public PlayerControls contoller;
    public bool global = false;
    public bool horizontal = false;
    public Vector3 currenttransform;
    public Text_InfoOpin_Zoom ti;
   void Start(){
        ti = FindObjectOfType<Text_InfoOpin_Zoom>();

    }
    
    public void Update()
    {

        if (!OverUI())
        {


            if (Input.GetMouseButton(0))
            {
                StopAllCoroutines();

                getTransPos();

                transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime, Space.World);
                transform.Rotate( -Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime, 0, 0);
                once = true;
            }


            if (Input.GetMouseButtonUp(0))
            {

                once = false;
                if (Input.mousePosition.x < previousPosition.y)
                {
                    rotInput -= (previousPosition.y - Input.mousePosition.x) / 5;

                    left = true;
                    right = false;
                    //transform.Rotate(0, -moveSpeed * Time.deltaTime * ((100 / leftBorder) * (leftBorder - Input.mousePosition.x) / 100), 0);
                }
                if (Input.mousePosition.x > previousPosition.y)
                {
                    //transform.Rotate(0, moveSpeed * Time.deltaTime * ((100 / (screenWidth - rightBorder)) * (Input.mousePosition.x - rightBorder) / 100), 0);
                    rotInput -= (previousPosition.y - Input.mousePosition.x) / 2;

                    right = true;
                    left = false;
                }


                //posdirection = transform.eulerAngles.y;

                StartCoroutine(rotate());

            }

        }
    }
   
    public float getTransPos()
    {
        if (!once)
        {


            previousPosition.y = Input.mousePosition.x;
            //Debug.Log("prevpos"+ previousPosition.y);
            once = true;

        }
        return previousPosition.y;
    }

   
    public IEnumerator rotate()
    {

        if (t == 5 && right == true)
        {

            while (t > 0 && !Input.GetMouseButton(0))
            {

                rotInput -= rotInput  * Time.deltaTime;
                t -= 2f * Time.deltaTime;
                transform.Rotate(Vector3.up * -rotInput * Time.deltaTime,Space.World);
                //transform.localScale = new Vector3(t * 0.5f, t * 0.5f, t * 0.5f);


                yield return null;
            }
            t = 5;
            StopCoroutine(rotate());
        }
        if (t == 5 && left == true)
        {
            while (t > 0 && !Input.GetMouseButton(0))
            {

                //Debug.Log("PosDelta" + postionDelta);
                rotInput -= rotInput  * Time.deltaTime;
                t -= 2f * Time.deltaTime;
                transform.Rotate(Vector3.up * rotInput * Time.deltaTime,Space.World);
                //transform.localScale = new Vector3(t * 0.5f, t * 0.5f, t * 0.5f);
                //  Debug.Log("Rotation:" + transform.rotation);

                yield return null;
            }

        }
        t = 5;
        StopCoroutine(rotate());
    }
bool OverUI()
    {

        PointerEventData currentMousePos = new PointerEventData(EventSystem.current);
        currentMousePos.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(currentMousePos, result);

            return result.Count>0;
    }
}