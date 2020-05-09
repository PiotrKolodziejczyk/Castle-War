using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            switch (transform.name)
            {
                case "SeaCollider":
                    mixer.FindSnapshot("Sea").TransitionTo(0);
                    break;
                case "ForestCollider":
                    mixer.FindSnapshot("Forest").TransitionTo(0);
                    break;
                case "MountainCollider":
                    mixer.FindSnapshot("Mountain").TransitionTo(0);
                    break;
            }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            mixer.FindSnapshot("Snapshot").TransitionTo(0);
    }
}

