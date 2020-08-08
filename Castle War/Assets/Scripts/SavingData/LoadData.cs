namespace Assets.Scripts.SavingData
{
    [System.Serializable]
    public class LoadData
    {
        public string text1;
        public string text2;
        public string text3;
        public string text4;
        public string text5;

        public LoadData(string text1, LoadSavingData data)
        {
            if (data.text1.text == "Save Template" && text1 != "")
            {
                this.text1 = text1;
                text1 = "";
            }
            else
                this.text1 = data.text1.text;
            if (data.text2.text == "Save Template" && text1 != "")
            {
                text2 = text1;
                text1 = "";
            }
            else
                text2 = data.text2.text;
            if (data.text3.text == "Save Template" && text1 != "")
            {
                text3 = text1;
                text1 = "";
            }
            else
                text3 = data.text3.text;
            if (data.text4.text == "Save Template" && text1 != "")
            {
                text4 = text1;
                text1 = "";
            }
            else
                text4 = data.text4.text;
            if (data.text5.text == "Save Template" && text1 != "")
            {
                text5 = text1;
                text1 = "";
            }
            else
                text5 = data.text5.text;

        }

    }
}
