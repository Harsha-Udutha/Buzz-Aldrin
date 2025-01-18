using UnityEngine;

public class MouseLook : MonoBehaviour
{
	private float xRotation;

	public float Sensitivity = 100f;

	public Transform playerBody;

	public Animator anim;

	public float range = 1f;

	private Camera fpsCam;

	public float swingRate = 0.5f;

	private float nextSwing;

	public int Score;

	public AudioSource wooshSoundEffect;

	private UIManager _uim;

	private GameManager _gm;

	private void Start()
	{
		fpsCam = Camera.main;
		_uim = GameObject.Find("Canvas").GetComponent<UIManager>();
		_gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void Update()
	{
		Look();
		if (Input.GetButtonDown("Fire1") && Time.time > nextSwing && anim != null)
		{
			nextSwing = Time.time + swingRate;
			Swing();
			anim.SetTrigger("swing");
			wooshSoundEffect.Play();
		}
	}

	private void Look()
	{
		float num = Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity;
		float num2 = Input.GetAxis("Mouse Y") * Time.deltaTime * Sensitivity;
		xRotation -= num2;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);
		base.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * num);
	}

	private void Swing()
	{
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out var hitInfo, range) && hitInfo.transform.CompareTag("Net"))
		{
			Object.Destroy(hitInfo.transform.gameObject, 0.2f);
			Score++;
			if (Score >= 100)
			{
				_gm.GameWon();
			}
			else if (Score == 50)
			{
				_gm.PlayMidAIDialouge();
			}
			_uim.UpdateSwarnCaughtText(Score);
		}
	}

	public void ChangeSensitivity(float CustomSensitivity)
	{
		Sensitivity = CustomSensitivity;
	}
}
