using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
	/*
	public Text t;
 
   	public void ChangeColour()
    {
        t.color = Color.blue;
    }
    */

 	/*
    public Text t;
    public bool clicked = false;

 	float r=255.0f,g=165.0f,b=0.0f,a=1.0f;

   	public void ChangeColour()
    {
    	if(Input.GetMouseButtonDown(0)){
    		if(!clicked) {

	    		t.color = new Color(r,g,b,a);
	    		clicked = true;
		    	} else {
	    		t.color = Color.white;
	    		clicked = false;
	    	}
     	}
    }
    */
    public Text t;
 	float r=0.80392156862f, g=0.86274509803f, b=0.22352941176f, a=1.0f; //205 220 57

   	public void ChangeColour()
    {
        t.color = new Color(r,g,b,a);
    }
    

    
    public void ColourWhite()
    {
        t.color = new Color(255,255,255,a);
    }
    
    


    /*
    public Text text;
	float r=0.2f,g=0.3f,b=0.7f,a=0.6f;

	void Start()
	{
	  text=gameobject.GetComponent<Text>();
	  text.color= new Color(r,g,b,a);
	}
	*/
}