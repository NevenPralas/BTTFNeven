using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotationCube : MonoBehaviour
{

   void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
