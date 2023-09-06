using UnityEngine;
using UnityEngine.EventSystems;

public class MovableUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private bool isDragging = false;
    private Vector3 offset;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Store the offset between the UI element's position and the click position
        offset = transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            // Move the UI element with the mouse/finger
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position) + offset;
            transform.position = newPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
