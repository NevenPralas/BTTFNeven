using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Open : MonoBehaviour
{

    public TextMeshProUGUI textMeshProUGUI;

    public GameObject gameObject;
    Animator animator;

     

    public void Click()
    {
        animator = gameObject.GetComponent<Animator>();

        textMeshProUGUI.color = Color.green;
        textMeshProUGUI.text = "OPEN";

        animator.SetBool("press", true);

        GlobalMemory.doorOpen = true;

    }
}
