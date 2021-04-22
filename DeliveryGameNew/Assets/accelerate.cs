using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerate : MonoBehaviour
{
    static AudioSource accelerateconstant;
    // Start is called before the first frame update
    void Start()
    {
        accelerateconstant = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W)))
        {
            Debug.Log("cock");
            accelerateconstant.volume = 0.8f;

        }
        if ((Input.GetKeyUp(KeyCode.W)))
        {
            accelerateconstant.volume = 0.0f;

        }
        

    }
    public static void ChangePitchUp()
	{

            accelerateconstant.pitch = 1.5f;
      
	}
    public static void ChangePitchDown()
    {

        accelerateconstant.pitch = 1.0f;

    }
}