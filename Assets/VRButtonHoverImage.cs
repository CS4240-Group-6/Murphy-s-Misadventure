using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRButtonHoverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalImage;
    public Sprite hoverImage;

    private Image buttonImage;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        SetNormalImage();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetHoverImage();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetNormalImage();
    }

    private void SetNormalImage()
    {
        if (buttonImage != null && normalImage != null)
        {
            buttonImage.sprite = normalImage;
        }
    }

    private void SetHoverImage()
    {
        if (buttonImage != null && hoverImage != null)
        {
            buttonImage.sprite = hoverImage;
        }
    }
}
