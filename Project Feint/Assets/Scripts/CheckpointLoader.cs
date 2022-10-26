using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointLoader : MonoBehaviour
{
    public static void Load(int checkpoint)
	{
		if (checkpoint == 0)
		{
			SceneManager.LoadScene("Level 1");
			Save.SaveCheckpoint(0);
		}
		else if (checkpoint == 1)
		{
			SceneManager.LoadScene("Level 1B");
		}
		else if (checkpoint == 2)
		{
			SceneManager.LoadScene("Level 2");
		}
		else if (checkpoint == 3)
		{
			SceneManager.LoadScene("Level 2B");
		}
		else if (checkpoint == 4)
		{
			SceneManager.LoadScene("Level 3");
		}
	}
}
