using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public TMP_Text SwarmCaughtText;

	public TMP_Text SwarmCaughtTextGo;

	public int SwarmCaught;

	public Slider asSlider;

	public Image ASFillImage;

	public GameObject GameOverPanel;

	public GameObject HudPanel;

	private void Start()
	{
		HudPanel.SetActive(value: false);
		GameOverPanel.SetActive(value: false);
		asSlider.value = 100f;
	}

	public void UpdateSwarnCaughtText(int newVar)
	{
		SwarmCaught = newVar;
		SwarmCaughtText.text = "Swarms Caught: " + newVar;
	}

	public void UpdateApartmentStabilitySlider(float newVar)
	{
		if (newVar <= 20f)
		{
			ASFillImage.color = Color.red;
		}
		else if (newVar <= 60.000004f)
		{
			ASFillImage.color = Color.yellow;
		}
		else
		{
			ASFillImage.color = Color.green;
		}
		asSlider.value = newVar;
	}

	public void GameOver()
	{
		SwarmCaughtTextGo.text = "Swarms Caught: " + SwarmCaught;
	}
}
