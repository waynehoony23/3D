using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public GameObject questPanel;
    public TextMeshProUGUI questText;
    public Image image;

    private QuestSaveData saveData;
    private int currentQuestID;

    void Awake()
    {
        if (Instance == null) Instance = this;
        saveData = SaveSystem.LoadQuestData();
    }

    public void TryStartQuest(PlantData data, Sprite img)
    {
        if (saveData.completedQuests[data.plantID])
        {
            Debug.Log($"{data.plantName}의 퀘스트는 이미 완료됨");
            return;
        }

        questPanel.SetActive(true);
        questText.text = $"[{data.plantName} 퀘스트]\n{data.questText}";
        image.sprite = img;
        
        currentQuestID = data.plantID;
    }

    public void ClearQuest()
    {
        saveData.completedQuests[currentQuestID] = true;
        saveData.score++;
        SaveSystem.SaveQuestData(saveData);
        questPanel.SetActive(false);
        Debug.Log($"퀘스트 {currentQuestID} 완료!");
    }

    public bool IsQuestCompleted(int id)
    {
        return id >= 0 && id < saveData.completedQuests.Length && saveData.completedQuests[id];
    }
}
