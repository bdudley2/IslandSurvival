using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialogue : MonoBehaviour
{

    bool inRange = false;
    // bool outRange = false;
    public Behaviour halo;
    public GameObject dialogueCanvas;
    public GameObject dialogueManager;
    
    private string speakerName = null;
    private Color speakerColor = Color.black;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas.SetActive(false);
        speakerName = this.name;
    }

    // Update is called once per frame
    void Update()
    {
        // pull up dialogue box
        if (Input.GetKeyDown(KeyCode.E) && inRange && !dialogueCanvas.activeSelf)
        {
            dialogueCanvas.SetActive(true);
            // dialogueManager.GetComponent<Dialogue>().SetBoxStyle(speakerName, speakerColor);
            dialogueManager.GetComponent<Dialogue>().SetCharacterIndex(speakerName);
            dialogueManager.GetComponent<Dialogue>().ResetDialogue();
            Debug.Log("User interacted with a character. Brings up Dialogue Box");
        }

        // leave dialogue box
        if (Input.GetKeyDown(KeyCode.X))
        {
            dialogueCanvas.SetActive(false);
            Debug.Log("User finished the interaction with the character");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if (other.GetType() == typeof(SphereCollider)) {
            if(other.gameObject.tag == "Player")
            {
                inRange = true;
                halo.enabled = true;
            }
        // }
    }
    void OnTriggerExit(Collider other)
    {
        // if (other.GetType() == typeof(SphereCollider)) {
            if (other.gameObject.tag == "Player")
            {
                inRange = false;
                halo.enabled = false;
            }
        // }
        // if (other.GetType() == typeof(BoxCollider)) {
        //     if(other.gameObject.tag == "Player")
        //     {
        //         outRange = true;
        //     }
        // }
        
    }
}
