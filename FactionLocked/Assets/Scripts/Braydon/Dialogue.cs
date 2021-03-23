using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// followed by tutorial on YouTube by BlackThornProd
// (modified to manage multiple conversations)
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI speakerDisplay;
    public Image speakerBackground;
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nextDisplay;
    // [CODE] // SentenceScripts scripts = new SentenceScripts();
    public string[,,] sentences = new SentenceScripts().FillSentences(); // first dim = conversations, second dim is its sentences
    public float textWaitTime = 0.02f;

    Coroutine currRoutine;
    private float storedTimeDelta;
    private bool buttonHeld = false;

    private TempQuestScript tQuest = new TempQuestScript();
    private int[] characterTalked = new int[3]; // 1 if the character index talked

    // public int convoIndex = 0;
    // private int index = 0;
    public int characterIndex = 0;
    private int[] savedConvoIndex = new int[10];
    private int[] savedIndex = new int[10];
    // private int endingIndex = 10;
    private bool isTextMoving = false;
    private float speedMult = 1f; // decrease to move text faster !!

    private bool isDone = false; // check is a dialogue scenario has reached it's current end


    public GameObject qc;

    public void ResetDialogue() {
        StopCoroutine(currRoutine);
        textDisplay.text = "";
        // savedIndex[characterIndex] = 0; // starting index for character's dialogue
        speedMult = 1f;
        isDone = false;
        currRoutine = StartCoroutine(TypingRoutine());
    }

    private void Start() {
        // \\----------- for temp quest script (Remove later)
        qc.SetActive(false);
        // \\----------- ------------------------------------
        textDisplay.text = "";
        speedMult = 1f;
        currRoutine = StartCoroutine(TypingRoutine());
    }

    IEnumerator TypingRoutine() {
        if (nextDisplay) nextDisplay.text = "";
        isTextMoving = true;
        if (!buttonHeld) speedMult = 1f;

        if (!buttonHeld) yield return new WaitForSeconds(textWaitTime * speedMult * 5f);

        // displays each letter in a sentences at some display speed
        foreach (var letter in sentences[characterIndex, savedConvoIndex[characterIndex], savedIndex[characterIndex]].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textWaitTime * speedMult);
        }

        if (!buttonHeld) yield return new WaitForSeconds(textWaitTime * speedMult * 15f);

        isTextMoving = false;
        if (nextDisplay && !isDone) nextDisplay.text = ">";
    }

    public void NextSentence() {
        if (savedIndex[characterIndex] < sentences.Length - 1) {
            // +++ Handle the end of a converstation here +++
            if (sentences[characterIndex, savedConvoIndex[characterIndex], savedIndex[characterIndex]+1] == "+") { // ends for a given dialogue text scenario
                StopCoroutine(currRoutine);
                if (nextDisplay) nextDisplay.text = "";
                textDisplay.text = "----  No more Text to Display (by index) -- Press X to leave ----";
                isDone = true;

                // Code for Temp Quest Prototype -------------------
                if (characterIndex != 0) {
                    characterTalked[characterIndex-1] = 1; // flag setting for temp talk quest
                    bool allTrue = true;
                    foreach (var i in characterTalked)
                    {
                        if (i == 0) {
                            allTrue = false;
                            break;
                        }
                    }
                    if (allTrue) {
                        if (savedConvoIndex[0] == 0 && savedIndex[0] <= 2) savedConvoIndex[0] = 5;
                        else savedConvoIndex[0] = 3;
                        // if (CharacterTalkQuest()) {
                        //     savedConvoIndex[characterIndex] = 3;
                        //     savedIndex[characterIndex] = 0;
                        //     return;
                        // }                   
                    }
                }
                else {
                    if (CharacterTalkQuest()) {
                        // savedConvoIndex[characterIndex] = 3;
                        savedIndex[characterIndex] = 0;
                        return;
                    }
                }
                // -------------------------------------------------

                // increment convo index for character if there is another dialogue, otherwise it should repeat
                if (sentences[characterIndex, savedConvoIndex[characterIndex]+1, 0] != null) {
                    savedConvoIndex[characterIndex]++;
                    savedIndex[characterIndex] = 0;
                }
                // } else {
                //     if (savedIndex[characterIndex] > 0) savedIndex[characterIndex]--; // repeats the last line only
                // }
                return;
            }
            savedIndex[characterIndex]++;
            textDisplay.text = "";
            currRoutine = StartCoroutine(TypingRoutine());
        } else {
            textDisplay.text = "----  No more Text to Display (by reaching end of array) ----";
        }
    }

    private void Update() {
        if (!isDone) {
            if (Input.GetKeyDown("f")) {
                if (!isTextMoving) {
                    NextSentence();
                } else {
                    toggleSpeedMult();
                }
            }

            // This allows us to hold down f and skip stuff even faster after a couple seconds
            if (Input.GetKey("f")) {
                storedTimeDelta += Time.deltaTime;
                if (storedTimeDelta >= 0.7f) {
                    buttonHeld = true;
                } else {
                    buttonHeld = false;
                }
                if (buttonHeld) {
                    if (!isTextMoving) {
                        NextSentence();
                    }
                    if (speedMult == 1f) toggleSpeedMult();
                }
            } else {
                storedTimeDelta = 0f;
            }
        }
    }

    private void toggleSpeedMult() {
        if (speedMult != 1f) {
            speedMult = 1f;
        } else {
            speedMult = 0.02f;
        }
    }

    // Sets the speaker name, speaker box color, and the correct character index to access their sentences
    public void SetCharacterIndex(string name) {
        if (speakerDisplay) speakerDisplay.text = name + ":";
        switch(name)
        {
            case "Thoughts":
                characterIndex = 0;
                speakerBackground.color = new Color(.231f,.164f,.302f,.7f); //59,42,77,180 (Purple-ish)
                break;
            case "Bob":
                characterIndex = 1;
                speakerBackground.color = new Color(0,.1f,.9f,.7f); // Blue
                break;
            case "Russ":
                characterIndex = 2;
                speakerBackground.color = new Color(.9f,.1f,0,.7f); // Red
                break;
            case "Sarah":
                characterIndex = 3;
                speakerBackground.color = new Color(.75f,.65f,.1f,.7f); // Yellow
                break;
            default:
                characterIndex = -1; // Should report an ERROR if here since -1 is not a valid index for arrays
                break;
        }

    }

    // sets flags for talking to each character, and checking quest status
    public bool CharacterTalkQuest() {
        if (tQuest.questCompleted == true) {
            return false;
        }
        bool isComplete = false;
        if (tQuest.questStarted == false) {
            qc.SetActive(true);
            isComplete = tQuest.StartQuest();
        } else {
            if (characterTalked[0] == 1) tQuest.blueTalked = true;
            if (characterTalked[1] == 1) tQuest.redTalked = true;
            if (characterTalked[2] == 1) tQuest.yellowTalked = true;
            isComplete = tQuest.CheckQuest();
        }
        if (savedConvoIndex[0] == 5) {
            tQuest.blueTalked = true;
            tQuest.redTalked = true;
            tQuest.yellowTalked = true;
            isComplete = tQuest.CheckQuest();
        }

        if (isComplete) {
            qc.GetComponentInChildren<TextMeshProUGUI>().text = "Quest Complete";
            qc.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
        }
        return isComplete;
    }

}
