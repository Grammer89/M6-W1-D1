using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
[Serializable]
public class PositionPlayerController : MonoBehaviour
{
    [SerializeField] Vector3 _positionPlayer;
    // Start is called before the first frame update
    private string _path;
    public struct Dir
    {
        public float x;
        public float y;
        public float z;

    }

    private void Awake()
    {
        _path = Application.persistentDataPath + "/SaveFile.json";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadJson();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            SaveJson();
        }
    }

    public void SaveJson()
    {
        _positionPlayer = transform.position;
        Dir newDir = new()
        {
            x = _positionPlayer.x,
            y = _positionPlayer.y,
            z = _positionPlayer.z
        };

        //string jsonText = JsonUtility.ToJson(_positionPlayer);
        //string jsonText = JsonConvert.SerializeObject(_positionPlayer);
        string jsonText = JsonConvert.SerializeObject(newDir);
        File.WriteAllText(_path, jsonText);
        Debug.Log("La posizione " + _positionPlayer + "è stata salvata nel path " + _path);
    }

    public void LoadJson()
    {
        string jsonText = File.ReadAllText(_path);
        //Vector3 data = JsonUtility.FromJson<Vector3>(jsonText);
        Vector3 data = JsonConvert.DeserializeObject<Vector3>(jsonText);
        Debug.Log(data);
        transform.position = data;
        Debug.Log("La posizione " + data + "è stata caricata dal path " + _path);
    }
}
