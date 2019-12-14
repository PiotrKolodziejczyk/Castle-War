using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildPanelManager : MonoBehaviour
{

    public Button button;

    public Canvas canvas;

    public TextMeshProUGUI titleText;

    public TextMeshProUGUI levelText;

    public TextMeshProUGUI woodText;

    public TextMeshProUGUI stoneText;

    public TextMeshProUGUI clayText;
    
    public TextMeshProUGUI timeText;
    public List<TextMeshProUGUI> canTexts;
    private void Awake()
    {
        canTexts = canvas.GetComponentsInChildren<TextMeshProUGUI>().Where(x => x.gameObject.tag == "BuldingText").ToList();
        
    }

}
