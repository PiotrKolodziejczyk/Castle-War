using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class SaveSystem
{
    public static void SaveCastle(PlayerCastle castle)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/playerCastle{Global.currentCastle}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        CastleData data = new CastleData(castle);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CastleData LoadCastle()
    {
        string path = Application.persistentDataPath + $"/playerCastle{Global.currentCastle}.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            CastleData data = formatter.Deserialize(stream) as CastleData;
            stream.Close();
            return data;
        }
        else
            return null;
    }
    public static void SavePlayer(UnitManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/player.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        PlayerData data = new PlayerData(player,null);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePlayer(TakeScript take)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/player.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        PlayerData data = new PlayerData(null,take);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + $"/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
            return null;
    }
}
