using UnityEngine;

// This is my save data model 
[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public string mapBoundary; // the bound name of current map
}
