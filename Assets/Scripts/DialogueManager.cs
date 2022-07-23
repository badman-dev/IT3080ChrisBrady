using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public List<GameObject> stages;

    string playerName = "";
    public TMP_InputField nameInput;
    public TextMeshProUGUI nameOutput;

    public void SetPlayerName()
    {
        string name = nameInput.text;

        if (name.Length > 0)
        {
            playerName = name;
        }
        else
        {
            playerName = "Quiet Type";
        }

        nameOutput.text = "Okay, " + name + ", would you like to embark on a quest for me?";
    }
    public void LoadStage(int index)
    {
        for (int i = 0; i < stages.Count; i++)
        {
            stages[i].SetActive(i == index);
        }
    }
}
