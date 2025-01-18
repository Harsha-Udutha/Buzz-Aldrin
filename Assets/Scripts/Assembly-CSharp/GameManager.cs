using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject Intro;

	public GameObject midAudio;

	public GameObject GameWonAudio;

	public GameObject GameOverAudio;

	public GameObject skipText;

	public GameObject HudPanel;

	public GameObject spawnBees;

	public GameObject playerNet;

	public GameObject GameOverPanel;

	public GameObject swarmCollection;

	public GameObject GameWonPanel;

	public GameObject pauseMenuPanel;

	private UIManager _uim;

	public AudioSource BgMusic;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		_uim = GameObject.Find("Canvas").GetComponent<UIManager>();
		Intro.SetActive(value: true);
		if (Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q) && Time.time < 100f)
		{
			GameStart();
		}
		else if (Time.time > 97f)
		{
			GameStart();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GamePaused();
		}
	}

	private void GameStart()
	{
		Intro.SetActive(value: false);
		skipText.SetActive(value: false);
		HudPanel.SetActive(value: true);
		spawnBees.SetActive(value: true);
		playerNet.SetActive(value: true);
		BgMusic.Play();
	}

	public void PlayMidAIDialouge()
	{
		midAudio.SetActive(value: true);
	}

	public void GameLost()
	{
		HudPanel.SetActive(value: false);
		_uim.GameOver();
		GameOverAudio.SetActive(value: true);
		playerNet.SetActive(value: false);
		StartCoroutine(EnableGameOverPanel());
	}

	public void GameWon()
	{
		GameWonAudio.SetActive(value: true);
		HudPanel.SetActive(value: false);
		playerNet.SetActive(value: false);
		StartCoroutine(ClearBuzz());
	}

	private IEnumerator ClearBuzz()
	{
		yield return new WaitForSeconds(7f);
		swarmCollection.SetActive(value: false);
		yield return new WaitForSeconds(29f);
		GameWonPanel.SetActive(value: true);
		Cursor.lockState = CursorLockMode.None;
	}

	private IEnumerator EnableGameOverPanel()
	{
		yield return new WaitForSeconds(11f);
		GameOverPanel.SetActive(value: true);
		Cursor.lockState = CursorLockMode.None;
	}

	public void QiutGame()
	{
		Application.Quit();
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.Locked;
		pauseMenuPanel.SetActive(value: false);
		HudPanel.SetActive(value: true);
	}

	private void GamePaused()
	{
		Cursor.lockState = CursorLockMode.None;
		Time.timeScale = 0f;
		HudPanel.SetActive(value: false);
		pauseMenuPanel.SetActive(value: true);
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
