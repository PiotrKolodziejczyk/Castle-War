using UnityEngine;
using UnityEngine.UI;
public class SmallMenu : MonoBehaviour
{
    bool isOn;

    public GameObject panel;

    private void Start()
    {
        isOn = false;
    }

    public void EnablePanel()
    {
        if (!isOn)
        {
            panel.SetActive(true);
            isOn = true;
        }
        else
        {
            panel.SetActive(false);
            isOn = false;
        }
    }
}
