using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Izlazak : MonoBehaviour
{
    
    public void Click(){
        Debug.LogError("KLIKNUTO!");
        Application.Quit();
    }
}
