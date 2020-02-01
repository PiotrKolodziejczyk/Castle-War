using UnityEngine;

public class SeaSounds : MonoBehaviour
{
    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            audio.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            audio.Stop();
    }
}
