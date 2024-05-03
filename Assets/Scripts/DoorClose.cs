using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public GameObject gameObject;
    Animator animator;
    public TextMeshProUGUI textMeshProUGUI;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="PlayerController")
        {
            animator.SetBool("press", false);
            GlobalMemory.doorOpen = false;
            textMeshProUGUI.color = Color.red;
            textMeshProUGUI.text = "CLOSED";
        }
    }
}
