using UnityEngine;
using System;
using System.IO;
[Serializable]
public class PositionPlayerController : MonoBehaviour
{
    [SerializeField] Vector3 _positionPlayer;
    // Start is called before the first frame update
    private string _path;

    private void Awake()
    {
        _path = Application.persistentDataPath + "/SaveFile.json";
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadJson();
        }

        if (Input.GetKey(KeyCode.Y))
        {
            SaveJson();
        }
    }

    public void SaveJson()
    {

        _positionPlayer = transform.position;
        string jsonText = JsonUtility.ToJson(_positionPlayer);
        File.WriteAllText(_path, jsonText);
        Debug.Log("La posizione " + _positionPlayer + "è stata salvata nel path " + _path);
    }

    public void LoadJson()
    {
        string jsonText = File.ReadAllText(_path);
        Vector3 data = JsonUtility.FromJson<Vector3>(jsonText);
        Debug.Log(data);
        transform.position = data;
        Debug.Log("La posizione " + _positionPlayer + "è stata caricata dal path " + _path);
    }
}
