using Assets.Scripts.HelpingClass;
using Assets.Scripts.MainScene;
using Assets.Scripts.SavingData;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class SaveSystem
{
    public static void SaveCastle(Castle castle, string savingPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{savingPath}{castle.Id}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        CastleData data = new CastleData(castle);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CastleData LoadCastle(int id, string savingPath)
    {
        string path = Application.persistentDataPath + $"/{savingPath}{id}.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            CastleData data = formatter.Deserialize(stream) as CastleData;
            stream.Close();
            return data;
        }
        else
            return null;
    }

    public static void SavePlayerPosition(UnitManager player, string savingPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        PlayerPositionData data = new PlayerPositionData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveAIPosition(AIController ai, string savingPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/aiPosition.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        AiPositionData data = new AiPositionData(ai);
        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static void SavePlayerArmyData(TakeScript take, string savingPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        PlayerArmyData data = new PlayerArmyData(take);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePlayerArmyData(PlayerArmyInBattle army, string savingPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        PlayerArmyData data = new PlayerArmyData(army);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePlayerArmyData(UnitManager army, string savingPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        PlayerArmyData data = new PlayerArmyData(army);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePlayerMaterialsData(MaterialsTake materials, string savingPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        PlayerMaterialsData data = new PlayerMaterialsData(materials);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePlayerMaterialsData(VillageScript materials, string savingPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        PlayerMaterialsData data = new PlayerMaterialsData(materials);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveEnemyArmyData(AISoldierController ai, string savingPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        AiArmyData data = new AiArmyData(ai);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveEnemyArmyData(AIArmy ai, string savingPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        AiArmyData data = new AiArmyData(ai);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerPositionData LoadPlayerPosition(string savingPath)
    {
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
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

    public static AiPositionData LoadAiPosition(string savingPath)
    {
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            AiPositionData data = formatter.Deserialize(stream) as AiPositionData;
            stream.Close();
            return data;
        }
        else
            return null;
    }
    public static PlayerArmyData LoadPlayerArmy(string savingPath)
    {
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
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
    public static PlayerMaterialsData LoadPlayerMaterials(string savingPath)
    {
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            PlayerMaterialsData data = formatter.Deserialize(stream) as PlayerMaterialsData;
            stream.Close();
            return data;
        }
        else
            return null;
    }
    public static AiArmyData LoadEnemyArmy(string savingPath)
    {
        string path = Application.persistentDataPath + $"/{savingPath}.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            AiArmyData data = formatter.Deserialize(stream) as AiArmyData;
            stream.Close();
            return data;
        }
        else
            return null;
    }
    public static SavingSaveData LoadSavingData(string nickName)
    {
        string path = Application.persistentDataPath + $"/savingData{nickName}.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            SavingSaveData data = formatter.Deserialize(stream) as SavingSaveData;
            stream.Close();
            return data;
        }
        else
            return null;
    }
    public static void SaveSavingData(GlobalInitializingClass save, string nickName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/savingData{nickName}.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        SavingSaveData data = new SavingSaveData(save);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveLoadData(string text1, LoadSavingData savingData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/LoadData1.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        LoadData data = new LoadData(text1, savingData);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static LoadData LoadLoadData()
    {
        string path = Application.persistentDataPath + $"/LoadData1.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            LoadData data = formatter.Deserialize(stream) as LoadData;
            stream.Close();
            return data;
        }
        else
            return null;
    }
}
