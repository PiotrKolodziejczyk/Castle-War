using Assets.Scripts.MainScene;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class SaveSystem
{
    public static void SaveCastle(PlayerCastle castle)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/playerCastle{Global.currentCastle}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
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
            FileStream stream = new FileStream(path, FileMode.Open,FileAccess.ReadWrite);
            CastleData data = formatter.Deserialize(stream) as CastleData;
            stream.Close();
            return data;
        }
        else
            return null;
    }
    public static void SavePlayerPosition(UnitManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/playerPosition.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        PlayerPositionData data = new PlayerPositionData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePlayerArmyData(TakeScript take)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/playerArmy1.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        PlayerArmyData data = new PlayerArmyData(take);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePlayerArmyData(PlayerArmyInBattle army)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/playerArmy.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        PlayerArmyData data = new PlayerArmyData(army);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerPositionData LoadPlayerPosition()
    {
        string path = Application.persistentDataPath + $"/playerPosition.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            PlayerPositionData data = formatter.Deserialize(stream) as PlayerPositionData;
            stream.Close();
            return data;
        }
        else
            return null;
    }
    public static PlayerArmyData LoadPlayerArmy()
    {
        string path = Application.persistentDataPath + $"/playerArmy1.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            PlayerArmyData data = formatter.Deserialize(stream) as PlayerArmyData;
            stream.Close();
            return data;
        }
        else
            return null;
    }
}
