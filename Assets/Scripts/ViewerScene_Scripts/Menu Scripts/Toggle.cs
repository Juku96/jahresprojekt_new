using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject panel;
 
 	bool on = false;

	public void toggle() {
		if(!on){
			panel.SetActive(true);
			on = true;
		} else {
			panel.SetActive(false);
			on = false;
		}
	}  
}
