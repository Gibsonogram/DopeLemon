using System.IO;
using Unity.Cinemachine;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        Debug.Log($"Save Location, {saveLocation}");

        LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition  = GameObject.FindGameObjectWithTag("Player").transform.position,
            mapBoundary     = FindFirstObjectByType<CinemachineConfiner2D>().BoundingShape2D.gameObject.name
        };
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }


    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));


            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Rigidbody2D>().position = saveData.playerPosition;
            FindFirstObjectByType<CinemachineConfiner2D>().BoundingShape2D = GameObject.Find(saveData.mapBoundary).GetComponent<PolygonCollider2D>();
        }
    }
}
