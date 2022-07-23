using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Quests;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;

    public GameObject questParent;
    public GameObject questPrefab;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddQuestSimple("test title");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            CompleteQuest("test title");
        }
    }

    public void AddQuestSimple(string title)
    {
        Quest newQuest = new Quest(title);

        quests.Add(newQuest);

        UpdateUI();
    }

    //public void AddQuest(string title, string description)
    //{
    //    Quest newQuest = new Quest(title, description);

    //    quests.Add(newQuest);

    //    UpdateUI();
    //}

    public void CompleteQuest(string title)
    {
        foreach (Quest q in quests)
        {
            if (q.title == title && !q.completed)
            {
                q.Complete();
                break;
            }
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        foreach (Transform child in questParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        float yOffset = 100;

        foreach (Quest q in quests)
        {
            if (!q.completed)
            {
                GameObject newQuestObject = Instantiate(questPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newQuestObject.transform.SetParent(questParent.transform);
                RectTransform newQuestTransform = newQuestObject.GetComponent<RectTransform>();
                newQuestTransform.anchorMin = new Vector2(0.5f, 1);
                newQuestTransform.anchorMax = new Vector2(0.5f, 1);
                newQuestTransform.localPosition = new Vector3(0, yOffset, 0);

                yOffset -= 50;

                TextMeshProUGUI test = newQuestObject.GetComponent<TextMeshProUGUI>();
                test.SetText("teststst");
                newQuestObject.GetComponent<TextMeshProUGUI>().SetText(q.title);
                //newQuestObject.GetComponentInChildren<TextMeshProUGUI>().SetText(q.description);
            }
        }
    }
}
