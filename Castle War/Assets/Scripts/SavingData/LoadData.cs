using System.Collections.Generic;
using System.Linq;

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

        public LoadData(string text1,LoadSavingData data)
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
                this.text2 = text1;
                text1 = "";
            }
            else
                this.text2 = data.text2.text;
            if (data.text3.text == "Save Template" && text1 != "")
            {
                this.text3 = text1;
                text1 = "";
            }
            else
                this.text3 = data.text3.text;
            if (data.text4.text == "Save Template" && text1 != "")
            {
                this.text4 = text1;
                text1 = "";
            }
            else
                this.text4 = data.text4.text;
            if (data.text5.text == "Save Template" && text1 != "")
            {
                this.text5 = text1;
                text1 = "";
            }
            else
                this.text5 = data.text5.text;

        }

    }
}
