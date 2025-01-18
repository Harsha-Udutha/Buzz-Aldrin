using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public GameObject MainMenuPanel;

	public GameObject TutorialPanel;

	public GameObject creditsPanel;

	public void PlayGame()
	{
		MainMenuPanel.SetActive(value: false);
		TutorialPanel.SetActive(value: true);
	}

	public void GoToCreditsPanel()
	{
		MainMenuPanel.SetActive(value: false);
		creditsPanel.SetActive(value: true);
	}

	public void GoBackToMainMenu()
	{
		MainMenuPanel.SetActive(value: true);
		creditsPanel.SetActive(value: false);
	}

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
