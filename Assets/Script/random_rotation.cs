using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_rotation : MonoBehaviour
{






    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(Random.value, Random.value, Random.value));
        this.transform.RotateAround(Vector3.zero, Vector3.zero, 4.0f);
    }
}
