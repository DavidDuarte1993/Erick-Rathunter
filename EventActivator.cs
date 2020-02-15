using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventActivator : MonoBehaviour
{
    public GameObject questCompleted;
    public GameObject fadescreen;
    public float timer;
    public string SceneToLoad;
    EventActivator instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void LoadScene()
    {
        StartCoroutine(loadsceneCo());
    }
    IEnumerator loadsceneCo()
    {
        questCompleted.SetActive(true);
        yield return new WaitForSeconds(timer);
        fadescreen.SetActive(true);
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(SceneToLoad);
        questCompleted.SetActive(false);
        fadescreen.SetActive(false);
    }

    private void Update()
    {
    }
}