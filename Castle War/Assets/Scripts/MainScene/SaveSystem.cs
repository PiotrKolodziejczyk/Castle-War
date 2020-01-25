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
}
