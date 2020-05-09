using UnityEngine;

public class EnableMap : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] bool isEnabled = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            if (!isEnabled)
                EnableMapMethod(true);
            else
                EnableMapMethod(false);
    }
    public void EnableMapMethod(bool onOff)
    {
        cam.enabled = onOff;
        isEnabled = onOff;
    }
}
