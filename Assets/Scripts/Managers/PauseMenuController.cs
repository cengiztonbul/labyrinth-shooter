using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
	GameObject pauseMenu;
	private bool _open = false;

	private void Start()
	{
		pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
		pauseMenu.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ToggleMenu();
		}
	}

	void ToggleMenu()
	{
		if (!_open)
		{
			_open = !_open;
			pauseMenu.SetActive(_open);
			Time.timeScale = 0;
		}
		else
		{
			_open = !_open;
			pauseMenu.SetActive(_open);
			Time.timeScale = 1;
		}
	}
}
