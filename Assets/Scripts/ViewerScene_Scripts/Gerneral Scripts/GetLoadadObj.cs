using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLoadadObj : MonoBehaviour
{
    public int passedObj;
    public GameObject[] activeObj;
    // Start is called before the first frame update
    void Start()
    {
       // passedObj = PlayerPrefs.GetInt("LoadedObj");
    
        activeObj = GameObject.FindGameObjectsWithTag("Player");
        
        for (int i = 0; i < activeObj.Length; i++) {
            activeObj[i].gameObject.AddComponent<LoadComapreObj>();
            activeObj[i].transform.position = new Vector3(0, 0, 0);
            if (activeObj[i].GetComponentInChildren<INfoButtonControl>() == null)
            { activeObj[i].name = activeObj[i].name.Replace("(Clone)", "").Trim(); 
                activeObj[i].transform.GetChild(0).gameObject.AddComponent<INfoButtonControl>();
            }
   
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
