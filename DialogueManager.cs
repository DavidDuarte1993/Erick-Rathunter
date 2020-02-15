﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;

    private PlayerController thePlayerController;

    // Start is called before the first frame update
    void Start()
    {
        thePlayerController = FindObjectOfType<PlayerController>();

        currentLine = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyUp(KeyCode.Space))
        {
            currentLine++;
        }

        if(currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
            thePlayerController.canMove = true;
        }

        if (currentLine < dialogLines.Length)
        {
            dText.text = dialogLines[currentLine];
        }
        //dText.text = dialogLines[currentLine];
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayerController.canMove = false;
    }
}
