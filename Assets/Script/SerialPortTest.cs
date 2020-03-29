using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialPortTest : MonoBehaviour
{
    //Setup parameters to connect to Arduino
    public static SerialPort sp = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
    public int message2;
    private float updatePeriod = 0.0f;
    public GameObject pushObject;

    // Use this for initialization
    void Start()
    {
        OpenConnection();
    }

    void Update()
    {
        updatePeriod += Time.deltaTime;
        if (updatePeriod > 0.2f)
        {
            //StartCoroutine(ReadInfo);
            message2 = sp.ReadByte();
            print(message2);
            Vector3 temp = pushObject.transform.position;
            temp.z = (155.0f - message2) / 10.0f;
            pushObject.transform.position = temp;
            updatePeriod = 0.0f;
        }

    }



    //Function connecting to Arduino
    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
                //message = "Closing port, because it was already open!";
            }
            else
            {
                sp.Open();  // opens the connection
                sp.ReadTimeout = 1000;  // sets the timeout value before reporting error
                print("Port Opened!");
                //		message = "Port Opened!";
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }
}