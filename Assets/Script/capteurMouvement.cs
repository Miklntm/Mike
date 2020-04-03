using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capteurMouvement : MonoBehaviour
{

    public int _data;
    public int data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;

            Vector3 profondeur = transform.localPosition;
            profondeur.z = _data;
            transform.localPosition = profondeur;



        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
