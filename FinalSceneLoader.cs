using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneLoader : MonoBehaviour
{
    public GameObject finalfadescreen;
    public GameObject titleimage;
    public GameObject finalphrase;
    public GameObject finalfadescreen2;
    public float timer;
    public float timer2;
    public float timer3;
    public float timer4;
    public string SceneToLoad;
    StoryDirector sDirector;

    void Start()
    {
        finalfadescreen.SetActive(false);
        titleimage.SetActive(false);
        finalphrase.SetActive(false);
        finalfadescreen2.SetActive(false);
        sDirector = FindObjectOfType<StoryDirector>();
    }
    public void LoadScene()
    {
        StartCoroutine(loadsceneCo());
    }
    IEnumerator loadsceneCo()
    {
        finalfadescreen.SetActive(true);
        yield return new WaitForSeconds(timer);
        titleimage.SetActive(true);
        yield return new WaitForSeconds(timer2);
        finalphrase.SetActive(true);
        yield return new WaitForSeconds(timer3);
        finalfadescreen2.SetActive(true);
        yield return new WaitForSeconds(timer4);
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