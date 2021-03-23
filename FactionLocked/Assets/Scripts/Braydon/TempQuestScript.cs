using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// temporary quest used to test out each character being talked to and updating the next conversation accordingly
public class TempQuestScript
{

    public bool questStarted = false;
    public bool questCompleted = false;
    public bool blueTalked = false;
    public bool redTalked = false;
    public bool yellowTalked = false;
    public bool StartQuest() {
        questStarted = true;
        bool status = CheckQuest();
        return status;
    }

    public bool CheckQuest() {
        if (blueTalked && redTalked && yellowTalked && questStarted) {
            questCompleted = true;
            return true;
        }
        return false;
    }
}
