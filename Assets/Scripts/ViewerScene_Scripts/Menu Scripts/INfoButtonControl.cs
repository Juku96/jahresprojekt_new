
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
    public GameObject info;
    public Transform[] infoText;



    // Start is called before the first frame update

    void Start()
    {

        buttonPrefabs = Resources.LoadAll("InfoButtons", typeof(GameObject)).Cast<GameObject>().ToArray();

        info = GameObject.FindGameObjectWithTag("MenuInfo");
        Zwrite = Resources.Load("Custom_StandardOccluded", typeof(Material)) as Material;
        Buttontransfrom = new Transform[buttonPrefabs.Length];
        infoText = new Transform[buttonPrefabs.Length];
        for (i = 0; i < buttonPrefabs.Length; i++)
        {

    
            Buttontransfrom[i] = transform.GetChild(i);
            Destroy(transform.GetChild(i).gameObject);
            Debug.Log(buttonPrefabs.Length);
            Debug.Log(info.gameObject.transform.GetChild(i));
            infoText[i] = info.gameObject.transform.GetChild(i);

        }
       
        buttons= new GameObject[buttonPrefabs.Length];
        for (j = 0; j < buttonPrefabs.Length; j++)
        {   
            infoText[j].GetComponentInChildren<Text>().text = Buttontransfrom[j].name;
            Debug.Log(infoText[j].transform.parent);
            buttonPrefabs[j].GetComponentInChildren<Text>().text= Buttontransfrom[j].GetComponentInChildren<Text>().text;
            buttonPrefabs[j].name = Buttontransfrom[j].name;
           
            buttons[j] = Instantiate(buttonPrefabs[j], Buttontransfrom[j].position, Buttontransfrom[j].transform.rotation);
            buttons[j].SetActive(true);
            objRenderer = buttons[j].GetComponent<Renderer>();
            objRenderer.material = Zwrite; 
            }



        cam = Camera.main;
      
    }
        
    

}
