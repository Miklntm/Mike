using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mer_separation2 : MonoBehaviour
{
    public GameObject Capsule;
    public float speed;


    void OnTriggerEnter(Collider col)
    {
        col.transform.position = Vector3.MoveTowards(col.transform.position, new Vector3(5,0,0), Time.deltaTime * 5.0f);
    }
}





