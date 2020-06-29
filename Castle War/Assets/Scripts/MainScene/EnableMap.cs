using UnityEngine;

public class EnableMap : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private bool isEnabled = false;
    [SerializeField] private GameObject map;
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.M))
        //    if (!isEnabled)
        //        EnableMapMethod(true);
        //    else
        //        EnableMapMethod(false);
    }
    public void EnableMapMethod(bool onOff)
    {
        if (onOff)
        {
            map.transform.localPosition = new Vector3(-0.0361f, 0.0147f, 2);
            map.transform.localScale = new Vector3(4, 2.3f, 1);
            isEnabled = true;
        }
        else
        {
            map.transform.localPosition = new Vector3(1.45f, -0.7968f, 1.9561f);
            map.transform.localScale = new Vector3(1, 0.7f, 1);
            isEnabled = false;

        }
    }
}
