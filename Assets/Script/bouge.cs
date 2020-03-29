using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouge : MonoBehaviour
{
    float speed = 3f;

    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }
}
