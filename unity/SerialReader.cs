using UnityEngine;
using System.IO.Ports;

public class SerialReader : MonoBehaviour
{
    private SerialPort sp;

    public PlayerController player;

    void Start()
    {
        try
        {
            sp = new SerialPort(@"\\.\COM6", 38400);
            sp.ReadTimeout = 50;
            sp.Open();

            Debug.Log("COM6 opened successfully");
        }
        catch (System.Exception e)
        {
            Debug.Log("Could not open COM6: " + e.Message);
        }
    }

    void Update()
    {
        if (sp == null || !sp.IsOpen)
            return;

        try
        {
            string data = sp.ReadLine().Trim();

            Debug.Log("Received: " + data);

            if (data == "JUMP")
            {
                player.Jump();
            }
            else if (data == "SLIDE")
            {
                Debug.Log("SLIDE RECEIVED");
                player.Slide();
            }
        }
        catch
        {
            // Ignore timeout errors
        }
    }

    void OnApplicationQuit()
    {
        if (sp != null && sp.IsOpen)
        {
            sp.Close();
            Debug.Log("COM6 closed");
        }
    }
}