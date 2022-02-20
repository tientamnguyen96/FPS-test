using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] RotationTouchpad _touchPad;
    private Image _bgImage;
    private Image _joystickImage;
    private Vector3 _inputVector;

    [HideInInspector]
    public bool started = false;
    public System.Action OnUserDrag;

    private void Start()
    {
        _bgImage = GetComponent<Image>();
        _joystickImage = transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
        if (!started && !_touchPad.IsTouchPadActive)
        {
            started = true;
        }
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        _inputVector = Vector3.zero;
        _joystickImage.rectTransform.anchoredPosition = Vector3.zero;
        started = false;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_bgImage.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / _bgImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _bgImage.rectTransform.sizeDelta.y);
            _inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;
            _joystickImage.rectTransform.anchoredPosition = new Vector3(_inputVector.x * (_bgImage.rectTransform.sizeDelta.x / 2), _inputVector.z * (_bgImage.rectTransform.sizeDelta.y / 2));
        }

        OnUserDrag?.Invoke();
    }
    public float Horizontal()
    {
        if (_inputVector.x != 0)
            return _inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (_inputVector.z != 0)
            return _inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }
}