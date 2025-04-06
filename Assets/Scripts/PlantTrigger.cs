using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlantTrigger : MonoBehaviour
{
    public int plantID;
    public Sprite image;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 퀘스트 창 띄우기
            PlantData data = PlnatDatabase.Instance.GetPlantDataByID(plantID);
            if (data != null)
            {
                QuestManager.Instance.TryStartQuest(data, image);
            }
            else
            {
                Debug.LogWarning($"ID {plantID}에 해당하는 식물 데이터가 없습니다.");
            }
        }
    }
}
