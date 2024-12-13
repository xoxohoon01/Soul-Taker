using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoSingleton<VirtualJoystick>, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Vector2 Input { get { return input; } }
    private Vector2 input = Vector2.zero;

    private Canvas canvas;
    private Camera cam = null;

    [SerializeField] private RectTransform handleArea = null;
    [SerializeField] private RectTransform handle = null;

    [SerializeField] private float handleRange = 1;
    [SerializeField] private float deadZone = 0;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        handle.anchoredPosition = Vector2.zero;
        Invoke("Connect", 0.1f);
    }

    public void Connect()
    {
        PlayerManager.Instance.player.controller.Input.moveJoystick = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, handleArea.position);
        Vector2 radius = handleArea.sizeDelta / 2;
        input = (eventData.position - position) / (radius * canvas.scaleFactor);
        HandleInput(input.magnitude, input.normalized);
        handle.anchoredPosition = input * radius * handleRange;
    }

    private void HandleInput(float magnitude, Vector2 normalised)
    {
        if (magnitude > deadZone)
        {
            if (magnitude > 1)
            {
                input = normalised;
            }
        }
        else
        {
            input = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}