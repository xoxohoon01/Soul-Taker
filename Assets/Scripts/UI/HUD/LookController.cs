using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LookController : MonoSingleton<LookController>, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 firstPoint;
    Vector3 secondPoint;

    public Vector3 firstRotation = Vector3.zero;
    public Vector3 secondRotation = Vector3.zero;

    public float lookSensitiviy = 0.25f;

    private float minRotationY = -45f;
    private float maxRotationY = 35f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        firstPoint = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        secondPoint = eventData.position;

        Vector2 input = secondPoint - firstPoint;
        secondRotation = firstRotation + new Vector3(-input.y * lookSensitiviy, input.x * lookSensitiviy, 0);
        secondRotation = new Vector3(Mathf.Clamp(secondRotation.x, minRotationY, maxRotationY), secondRotation.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        firstRotation = secondRotation;
    }
}
