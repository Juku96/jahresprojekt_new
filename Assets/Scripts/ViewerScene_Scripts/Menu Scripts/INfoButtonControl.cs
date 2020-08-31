
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    public UnityEngine.Vector3 clickPos;
    public Text_InfoOpin_Zoom ti;


    // Start is called before the first frame update

    void Start()
    {
        ti = GameObject.FindGameObjectWithTag("canvasKlara").GetComponent<Text_InfoOpin_Zoom>();
        buttonPrefabs = Resources.LoadAll("InfoButtons", typeof(GameObject)).Cast<GameObject>().ToArray();

        info = GameObject.FindGameObjectWithTag("MenuInfo");
        Zwrite = Resources.Load("Custom_StandardOccluded", typeof(Material)) as Material;
        Buttontransfrom = new Transform[buttonPrefabs.Length];
        infoText = new Transform[buttonPrefabs.Length];
        for (i = 0; i < buttonPrefabs.Length; i++)
        {

    
            Buttontransfrom[i] = transform.GetChild(i);
            Destroy(transform.GetChild(i).gameObject);

          
            infoText[i] = info.gameObject.transform.GetChild(i);
           
        }
       
        buttons= new GameObject[buttonPrefabs.Length];
        for (j = 0; j < buttonPrefabs.Length; j++)
        { int _i = j;
            infoText[j].GetComponentInChildren<Text>().text = Buttontransfrom[j].name;
            
    
            buttonPrefabs[j].name = Buttontransfrom[j].name;
            
            buttons[j] = Instantiate(buttonPrefabs[j], Buttontransfrom[j].position, Buttontransfrom[j].transform.rotation);
            buttons[j].SetActive(true);
            buttons[j].GetComponentInChildren<Text>().text = Buttontransfrom[j].GetComponentInChildren<Text>().text;
            objRenderer = buttons[j].GetComponent<Renderer>();
            objRenderer.material = Zwrite; 
            infoText[j].GetComponent<Button>().onClick.AddListener(() => ti.InfoMenuClicked(buttons[_i]));
        }



        cam = Camera.main;
      
    }
        
    

}
