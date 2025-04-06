
using System;

[Serializable]
public class PlantData
{
    public int plantID;
    public string plantName;
    public string questText;
}

[Serializable]
public class PlantDataList
{
    public PlantData[] plants;
}
