using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorClose2 : MonoBehaviour
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
        if (other.name == "PlayerController" && GlobalMemory.izvana == true)
        {
            animator.SetBool("press", false);
            GlobalMemory.doorOpen = false;
            GlobalMemory.izvana = false;
            textMeshProUGUI.color = Color.red;
            textMeshProUGUI.text = "CLOSED";
        }
    }
}
