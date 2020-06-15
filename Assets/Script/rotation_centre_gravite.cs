using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_centre_gravite : MonoBehaviour
{






    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(Random.value, Random.value, Random.value));
        this.transform.RotateAround(Vector3.zero, Vector3.up, 1.5f);
    }
}
