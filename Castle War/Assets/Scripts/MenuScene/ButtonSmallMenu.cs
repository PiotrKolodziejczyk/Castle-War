using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSmallMenu : MonoBehaviour, IPointerEnterHandler,IPointerClickHandler
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip clip;

    public void OnPointerClick(PointerEventData eventData)
    {
        source.PlayOneShot(clip);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        source.Play();
    }
    
}
