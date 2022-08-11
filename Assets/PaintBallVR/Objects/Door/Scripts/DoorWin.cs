using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWin : MonoBehaviour
{
    Animator anim;
    public ParticleSystem win;

    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetScore() >= 5)
        {
            anim.SetTrigger("OpenDoor");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            win.Play();
            button.SetActive(true);
        }
    }
}
