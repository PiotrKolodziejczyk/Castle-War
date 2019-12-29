using UnityEngine;

public class TriggersScript : MonoBehaviour
{
    bool isRunZ;
    bool isRunX;
    public float rangeZFrom;
    public float rangeZTo;
    public float rangeXFrom;
    public float rangeXTo;

    private void Update()
    {
        if (transform.position.z < rangeZFrom && isRunZ && rangeZFrom != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
        }
        else
        {
            isRunZ = false;
        }
        if (transform.position.z > rangeZTo && !isRunZ && rangeZTo != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        }
        else
        {
            isRunZ = true;
        }
        if (transform.position.x < rangeXFrom && isRunX && rangeXTo != 0)
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }
        else
        {
            isRunX = false;
        }
        if (transform.position.x > rangeXTo && !isRunX && rangeXFrom != 0)
        {
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }
        else
        {
            isRunX = true;
        }

    }
}
