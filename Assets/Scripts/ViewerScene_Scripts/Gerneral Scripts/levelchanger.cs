using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;


public class levelchanger : MonoBehaviour
{
    public GameObject Statue;
    public float progress;
    public int levelToLoad;
    public bool loadScene = false;
    public Text loadingText;
    public Animator animator;
    public Slider slider;
    public Text percentage;
    public GameObject canvas;
    PlayerControls controls;
    public static levelchanger lvch; 
    public GameObject selectedchar;
    
    void Awake()
    {

        controls = new PlayerControls();
        controls.MouseControl.Move.performed += ctx => toStatue();

    }
    private void OnEnable()
    {
        controls.MouseControl.Enable();
    }
    public void Start()
    {
        lvch = this;
    }

    void toStatue()
    {
    
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50) && (hit.collider.gameObject == selectedchar)&& loadScene == false)
        {
            loadScene = true;
            canvas.SetActive(true);

            StartCoroutine(FadeToLevel(1));
            Debug.Log("hit : " + hit.collider.gameObject.name);

        }

    }


    IEnumerator FadeToLevel(int levelInex)
    {
        levelToLoad = levelInex;
        animator.SetTrigger("Fade Out");


      
 
        
       // progress = Mathf.Clamp01(async.progress / 0.9f);
        percentage.text = progress * 100f + "%";


        //   while (!async.isDone)
        // {
        while (progress<=1.1) {
            progress += 0.3f * Time.deltaTime;
            slider.value = progress;
            percentage.text = (progress*100).ToString("F0") + "%";
            Debug.Log("prgoress" + progress);
            if (progress >= 1f)
            {
               
                AsyncOperation async = SceneManager.LoadSceneAsync(levelToLoad);
                async.allowSceneActivation = true;

                StopAllCoroutines();
            }
            yield return null;
        }
       // }
    }
}
