using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PastPresentFuture : MonoBehaviour
{

    public TextMeshProUGUI textMeshProUGUI1;
    public TextMeshProUGUI textMeshProUGUI2;
    public TextMeshProUGUI textMeshProUGUI3;

    public Sprite spritePast;
    public Sprite spritePresent;
    public Sprite spriteFuture;

    public Image image;

    public GameObject past;
    public GameObject future;
    public GameObject present;


    public void Past()
    {
        if (!GlobalMemory.doorOpen)
        {
            textMeshProUGUI1.text = "PAST";
            textMeshProUGUI1.color = Color.magenta;

            textMeshProUGUI2.text = "PAST";
            textMeshProUGUI2.color = Color.magenta;

            textMeshProUGUI3.text = "PAST";
            textMeshProUGUI3.color = Color.magenta;

            GlobalMemory.doba = "PAST";

            past.SetActive(true);
            future.SetActive(false);
            present.SetActive(false);

            image.sprite = spritePast;
        }
    }

    public void Present()
    {
        if (!GlobalMemory.doorOpen)
        {
            textMeshProUGUI1.text = "PRESENT";
            textMeshProUGUI1.color = new Color(255, 230, 0, 255);

            textMeshProUGUI2.text = "PRESENT";
            textMeshProUGUI2.color = new Color(255, 230, 0, 255);

            textMeshProUGUI3.text = "PRESENT";
            textMeshProUGUI3.color = new Color(255, 230, 0, 255);


            GlobalMemory.doba = "PRESENT";

            past.SetActive(false);
            future.SetActive(false);
            present.SetActive(true);

            image.sprite = spritePresent;
        }
    }

    public void Future()
    {
        if (!GlobalMemory.doorOpen)
        {
            textMeshProUGUI1.text = "FUTURE";
            textMeshProUGUI1.color = Color.blue;

            textMeshProUGUI2.text = "FUTURE";
            textMeshProUGUI2.color = Color.blue;

            textMeshProUGUI3.text = "FUTURE";
            textMeshProUGUI3.color = Color.blue;

            GlobalMemory.doba = "FUTURE";

            past.SetActive(false);
            future.SetActive(true);
            present.SetActive(false);

            image.sprite = spriteFuture;
        }
    }

}
