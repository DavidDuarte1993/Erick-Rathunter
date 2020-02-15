using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneLoader : MonoBehaviour
{
    public GameObject fadescreen;
    public float timer;
    public string SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoadScene()
    {
        StartCoroutine(loadsceneCo());
    }
    IEnumerator loadsceneCo()
    {
       fadescreen.SetActive(true);
       yield return new WaitForSeconds(timer);
       SceneManager.LoadScene(SceneToLoad);
       fadescreen.SetActive(false);
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LoadScene();
        }
    }
}
