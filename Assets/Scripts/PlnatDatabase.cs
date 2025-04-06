using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlnatDatabase : MonoBehaviour
{
    public static PlnatDatabase Instance { get; private set; }
    private PlantDataList plantDataList;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadPlantData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadPlantData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Data/plant_data");
        if (jsonFile != null)
        {
            plantDataList = JsonUtility.FromJson<PlantDataList>(jsonFile.text);
            Debug.Log("식물 데이터 로드 완료!");
        }
        else
        {
            Debug.LogError("식물 데이터 파일을 찾을 수 없습니다.");
        }
    }

    public PlantData GetPlantDataByID(int id)
    {
        foreach (var data in plantDataList.plants)
        {
            if (data.plantID == id)
                return data;
        }

        return null;
    }
}
