using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DeleteAllSave : MonoBehaviour
{
    public List<Text> texts;
    
    public void Delete()
    {
      var list =  Pobierz_Pliki(Application.persistentDataPath);
        foreach(var item in list)
        {
            File.Delete(item);
        }
        ResetTexts();
    }
    public void ResetTexts()
    {
        foreach(var item in texts)
        {
            item.text = "Save Template";
        }
    }
    public static List<string> Pobierz_Pliki(string sciezka)
    {
        Directory.GetFiles(sciezka);
        List<string> pliki = Directory.GetFiles(sciezka).ToList<string>();
        return pliki;
    }
}
