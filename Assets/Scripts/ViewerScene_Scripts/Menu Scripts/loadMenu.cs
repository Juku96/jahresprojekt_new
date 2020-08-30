using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject activeObj;   

public void loadScene()
    {
        activeObj = GameObject.FindGameObjectWithTag("Player");
        Destroy(activeObj);
        SceneManager.LoadSceneAsync("StartMenu");
        
    }
}
