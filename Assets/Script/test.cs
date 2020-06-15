using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{


    float angle;

    [SerializeField]
    float rotateSpeed;




    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        angle += rotateSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, 0);
    }








}

