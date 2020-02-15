using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryDirector : MonoBehaviour
{
    public GameObject storyBox;
    public Text storyText;
    public string[] storyLines;
    public int currentText;
    public int activationLine;
   

    // Start is called before the first frame update
    void Start()
    {
        storyBox.SetActive(true);
        currentText = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentText++;
        }

        if (currentText >= storyLines.Length)
        {
            storyBox.SetActive(false);
        }

        if (currentText < storyLines.Length)
        {
            storyText.text = storyLines[currentText];
        }
    }
}
