using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{

    public GameObject[] wayPoints;
    int index = 0;

    int prethodni = 0;

    [SerializeField] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, wayPoints[index].transform.position) < 0.1f)
        {
            if (index == 0) index = 1;
            else index = 0;
        }

        if (prethodni != index)
        {
            if (prethodni == 0) prethodni = 1;
            else prethodni = 0;

            transform.Rotate(0f, 180f, 0f);
        }


        transform.position = Vector3.MoveTowards(transform.position, wayPoints[index].transform.position, speed * Time.deltaTime);
    }
}
