using UnityEngine;
using UnityEngine.UI;

public class LoadSavingData : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;

    private void Awake()
    {
        var data = SaveSystem.LoadLoadData();


        if(data != null)
        {
            if (data.text1 == "Save Template")
                text1.text = "Save Template";
            else
                text1.text = data.text1;
            if (data.text2 == "Save Template")
                text2.text = "Save Template";
            else
                text2.text = data.text2;
            if (data.text3 == "Save Template")
                text3.text = "Save Template";
            else
                text3.text = data.text3;
            if (data.text4 == "Save Template")
                text4.text = "Save Template";
            else
                text4.text = data.text4;
            if (data.text5 == "Save Template")
                text5.text = "Save Template";
            else
                text5.text = data.text5;
        }
        else
        {
            text1.text = "Save Template";
            text2.text = "Save Template";
            text3.text = "Save Template";
            text4.text = "Save Template";
            text5.text = "Save Template";
        }
        
    }

}
