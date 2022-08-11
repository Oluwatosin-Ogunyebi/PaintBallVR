using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            anim.SetTrigger("CloseDoor");
        }
    }
}
