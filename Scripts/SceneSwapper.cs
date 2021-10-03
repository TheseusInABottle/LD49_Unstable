using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetButton("Jump"))
		{
			Scene curScene = SceneManager.GetActiveScene();
			if (curScene.buildIndex == 0)
			{
				SceneManager.LoadScene(1);
			}
			else
			{
				SceneManager.LoadScene(0);
			}

		}
	}
}
