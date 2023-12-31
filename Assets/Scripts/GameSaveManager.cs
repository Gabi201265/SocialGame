using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameSaveManager : MonoBehaviour
{
    public SO_CharacterDescription characterDescription;
    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/game_save");
    } 
    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }
        if(!Directory.Exists(Application.persistentDataPath + "/game_save/character_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/character_data");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/game_save/character_data/character_description.txt");
        var json = JsonUtility.ToJson(characterDescription);
        bf.Serialize(file, json);
        file.Close();
    }

    public void LoadGame()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/game_save/character_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/character_data");
        }
        BinaryFormatter bf = new BinaryFormatter();

        if(File.Exists(Application.persistentDataPath + "/game_save/character_data/character_description.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_save/character_data/character_description.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), characterDescription);
            file.Close();
        }
    }
}
