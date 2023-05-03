using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Dialogue[] dialogues;
    public DialogueReader reader;
    public bool isReaded;
    private void Start()
    {
        dialogues = gameObject.GetComponent<InteractionEvent>().GetDialogue();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !reader.GetisReading())
        {
            reader.SetDialogue(dialogues);
        }
    }
}
