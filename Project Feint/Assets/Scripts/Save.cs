using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    public static void SaveCheckpoint(int value)
	{
        PlayerPrefs.SetInt("checkpoint", value);
	}

    // Update is called once per frame
    public static void LoadCheckpoint()
    {
        int temp;
        temp = PlayerPrefs.GetInt("checkpoint");
        Debug.Log("Going to Checkpoint " + temp);
        CheckpointLoader.Load(temp);
    }
    public static void LoadFirstCheckpoint()
	{
        CheckpointLoader.Load(0);
	}
}
