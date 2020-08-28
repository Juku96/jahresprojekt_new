using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
	/*
	public Material [] skyboxes;

	int skyboxCounter = 0;

	int currentSkyboxNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skyboxes [currentSkyboxNumber]; //choos which skybox to display first
    }

    public void ChangeSkybox()
    {
    	skyboxCounter++;
    	if (skyboxCounter >= skyboxes.Length){
    		skyboxCounter = 0;
    	}
    	RenderSettings.skybox = skyboxes [skyboxCounter]; //Display skybox with that number
    }
    */

    public Material [] skyboxes;

	int skyboxCounter = 0;

	int currentSkyboxNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skyboxes [currentSkyboxNumber]; //choos which skybox to display first
    }

    public void ChangeSkybox1()
    {
    	RenderSettings.skybox = skyboxes [0]; //Display skybox with that number
    }

    public void ChangeSkybox2()
    {
    	RenderSettings.skybox = skyboxes [1]; //Display skybox with that number
    }

    public void ChangeSkybox3()
    {
    	RenderSettings.skybox = skyboxes [2]; //Display skybox with that number
    }

    public void ChangeSkybox4()
    {
    	RenderSettings.skybox = skyboxes [3]; //Display skybox with that number
    }
    
}
