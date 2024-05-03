using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardwareRig : MonoBehaviour
{
    public HardwareHand leftHand;
    public HardwareHand rightHand;
    public HardwareHead headSet;

    public static HardwareRig Instance;

    private void Start()
    {
        Instance = this;
    }
}
