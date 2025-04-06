using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string filePath => Path.Combine(Application.persistentDataPath, "quest_save.json");

    public static void SaveQuestData(QuestSaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log($"퀘스트 저장됨: {filePath}");
    }

    public static QuestSaveData LoadQuestData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<QuestSaveData>(json);
        }
        else
        {
            Debug.Log("세이브 파일 없음, 새로 생성");
            return new QuestSaveData { completedQuests = new bool[100] }; // 100개까지 대응
        }
    }
}