using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    //public Transform button;
    //public Transform buttonUp;
    //public Transform buttonDown;

    public Transform buttonPosition, buttonUpPosition, buttonDownPosition;
    public UnityEvent onButtonPressed;
    public UnityEvent onButtonReleased;

    public void OnPressed()
    {
        buttonPosition.position = buttonDownPosition.position;
        onButtonPressed.Invoke();
    }

    public void OnReleased()
    {
        buttonPosition.position = buttonUpPosition.position;
        onButtonReleased.Invoke();
    }
}
