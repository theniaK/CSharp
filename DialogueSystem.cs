using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {


    public static DialogueSystem Instance { get; set; }
    public List<string> dialogueLines = new List<string>(); // This list contains the dialogue lines.
    public string npcName;
    public GameObject dialoguePanel; // It will give us everything that will be in a dialogue box.


    Button continueButton;
    Text dialogueText , nameText;
    int dialogueIndex; // A variable that shown on what line we are on the dialogue.
     
    // Use this for initialization
    void Awake () 
    {
        continueButton = dialoguePanel.transform.FindChild("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.FindChild("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false); // the dialogue menu will not show.

        if (Instance != null && Instance != this) // Checks if there is a dialogue.
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

	}
	
	public void AddNewDialogue(string[] lines , string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length); // we create an empty dialogue.
        dialogueLines.AddRange(lines);
        this.npcName = npcName; // creating instance.
        Debug.Log(dialogueLines.Count);

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }
    public void ContinueDialogue()
    {
        if (dialogueIndex <= dialogueLines.Count -1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
