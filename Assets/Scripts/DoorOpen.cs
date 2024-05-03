using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject gameObject;
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerController")
        {
            animator.SetBool("press", true);
            GlobalMemory.doorOpen = true;
        }
    }
}
