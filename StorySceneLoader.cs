using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySceneLoader : MonoBehaviour
{
    public GameObject finalfadescreen;
    public float timer;
    public string SceneToLoad;
    StoryDirector sDirector;

    void Start()
    {
        sDirector= FindObjectOfType<StoryDirector>();
    }
    public void LoadScene()
    {
        StartCoroutine(loadsceneCo());
    }
    IEnumerator loadsceneCo()
    {
        finalfadescreen.SetActive(true);
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(SceneToLoad);
    }

    private void Update()
    {
        if (sDirector.currentText == sDirector.activationLine && Input.GetKeyUp(KeyCode.Space))
        {
            LoadScene();
        }
    }
}