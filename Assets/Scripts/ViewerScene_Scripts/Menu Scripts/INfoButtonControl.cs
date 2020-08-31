
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class INfoButtonControl : MonoBehaviour
{
    public GameObject[] buttonPrefabs;

    public GameObject[] buttons;
   // public GameObject[] Instanciatedbuttons;
    public Text placeholder;
    public Camera cam;
    int i=0;
    int j;
    Material Zwrite;
    Material buttonMaterial;
    bool running =false;
    
    public Renderer objRenderer;
    public Transform[] Buttontransfrom;




    // Start is called before the first frame update

    void Start()
    {

        buttonPrefabs = Resources.LoadAll("InfoButtons", typeof(GameObject)).Cast<GameObject>().ToArray();
       
       
        Zwrite = Resources.Load("Custom_StandardOccluded", typeof(Material)) as Material;
        Buttontransfrom = new Transform[buttonPrefabs.Length];
        for (i = 0; i < buttonPrefabs.Length; i++)
        {

            
            Buttontransfrom[i] = transform.GetChild(i);
            
          //  Destroy(transform.GetChild(i).gameObject);
           
        }

        buttons= new GameObject[buttonPrefabs.Length];
        for (j = 0; j < buttonPrefabs.Length; j++)
        {
           buttonPrefabs[j].GetComponentInChildren<Text>().text= Buttontransfrom[j].GetComponentInChildren<Text>().text;
   
            buttons[j] = Instantiate(buttonPrefabs[j], Buttontransfrom[j].position, Buttontransfrom[j].transform.rotation);
            buttons[j].SetActive(true);
            objRenderer = buttons[j].GetComponent<Renderer>();
            objRenderer.material = Zwrite; 
            }
              
        
        cam = Camera.main;
      
    }
        
    

}
