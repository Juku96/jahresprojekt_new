
using UnityEditor;

using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class LoadComapreObj : MonoBehaviour
{
    public GameObject[] compareObjects;

    public GameObject compareButton;





    // Start is called before the first frame update

    void Start()
    {



        if (gameObject.name == "Katze_Fertig")
        {
            compareObjects = Resources.LoadAll<GameObject>("Vergleichsobjekte/Banana");

            createButton(compareObjects);

        }
        if (gameObject.name == "Miniatur_Fertig")
        {

            compareObjects = Resources.LoadAll<GameObject>("Vergleichsobjekte/Audi R8");

            createButton(compareObjects);
        }
        if (gameObject.name == "Kopf_Fertig")
        {
            compareObjects = Resources.LoadAll<GameObject>("Vergleichsobjekte/75-chevrolet_camaro_ss");
            createButton(compareObjects);

        }
        if (gameObject.name == "Stein_Fertig")
        {
            compareObjects = Resources.LoadAll<GameObject>("Vergleichsobjekte/Audi R8");
            createButton(compareObjects);


        }


    }







    public void createButton(GameObject[] obj)
    {


    



        for (int i = 0; i < 1; i++)
        {
            obj[i].SetActive(false);

            compareButton = GameObject.FindGameObjectWithTag("Vergleich");

            obj[i] = Instantiate(obj[i], gameObject.transform.position + new Vector3(6.5f, 0f, 0f), Quaternion.identity);

            compareButton.GetComponent<Button>().onClick.AddListener(() => GetCurrentObj(i - 1, obj));



        }

    }


    public void GetCurrentObj(int j, GameObject[] obj)

    {


        if (obj[j].activeSelf == false)
        {


            obj[j].SetActive(true);
        }
        else if (obj[j].activeSelf == true)
        {

            obj[j].SetActive(false);

        }
    }


}


