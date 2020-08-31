using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index = 0;
    private int PlayerRight;
    private int PlayerLeft;
    private GameObject passedObj;
    public GameObject SelectedObj;
    public GameObject Podest;
    public GameObject[] Podests;

    // Start is called before the first frame update
    void Start()
    { /*Podest = Resources.Load("Podest_Prefabs", typeof(GameObject)) as GameObject;

       
        Podests = new GameObject[characterList.Length];
        for(int i =0; i<Podests.Length; i++) { 
        Instantiate(Podests[i], Podests[i], )*/
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene ();
        characterList = new GameObject[transform.childCount];
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        index = PlayerPrefs.GetInt("CharacterSelected");

        //Debug.Log("test");

        //Fill the array with our models
        for(int i = 0; i < transform.childCount; i++) {
          characterList[i] = transform.GetChild(i).gameObject;
           
          // Alle Objekte unsichtbar
          characterList[i].SetActive(false);
        }

        if(sceneName == "ViewerScene") {
          if(characterList[index]) {
             characterList[index].SetActive(true);
          }
        }
        else {
          // Ausgewähltes Objekt sichtbar machen
          if(characterList[index]) {
            TogglePlayer(index);
          }
        }

    }

    void Update() {
      if (Input.GetKeyUp("left"))
        {
            ToggleLeft();
        }

        if (Input.GetKeyUp("right"))
        {
            ToggleRight();
        }
    }

    public void ToggleLeft() {
      TogglePlayer(-1);
    }

    public void ToggleRight() {
      TogglePlayer(+1);
    }

    public void confirmObject() {
      characterList[PlayerRight].SetActive(false);
      characterList[PlayerLeft].SetActive(false);
      SelectedObj = GameObject.Find(characterList[index].name);
   
       passedObj= Instantiate(SelectedObj, transform.position, Quaternion.identity);


        // Szene Laden
        PlayerPrefs.SetInt("LoadedObj",index);
        SceneManager.LoadSceneAsync("ViewerScene"); //Name von Szene muss noch geändert werden
        DontDestroyOnLoad(passedObj);
    }



    private void TogglePlayer(int n) {
      characterList[index].SetActive(false);
      characterList[PlayerLeft].SetActive(false);
      characterList[PlayerRight].SetActive(false);

      index = index + n;

      if(index<0) index = characterList.Length-1;
      else if(index>transform.childCount-1) index = 0;

      characterList[index].transform.position = new Vector3(0, transform.position.y, transform.position.z);
      characterList[index].SetActive(true);

      PlayerRight = index+1;
      PlayerLeft = index-1;

      if(PlayerRight>transform.childCount-1) PlayerRight=0;
      if(PlayerLeft<0) PlayerLeft=characterList.Length-1;

      characterList[PlayerLeft].transform.position = new Vector3(-6, transform.position.y, transform.position.z);
      characterList[PlayerLeft].SetActive(true);
      characterList[PlayerRight].transform.position = new Vector3(6, transform.position.y, transform.position.z);
      characterList[PlayerRight].SetActive(true);
    }

}
