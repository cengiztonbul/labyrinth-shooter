using UnityEditor;
using UnityEngine;

class QuitGame : MonoBehaviour
{
	public void QuitApp()
	{
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#endif
		Application.Quit();
	}
}