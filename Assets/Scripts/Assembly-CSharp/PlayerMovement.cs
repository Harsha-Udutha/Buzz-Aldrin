using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;

	public float speed = 12f;

	public float gravity = -9.18f;

	public float jumpHeight = 5f;

	private Vector3 velocity;

	public Transform groundCheck;

	public float groundDistance = 0.4f;

	public LayerMask groundMask;

	private bool isGrounded;

	public bool CanShiftGravity;

	public Animator anim;

	public int health = 100;

	private GameManager _gm;

	private UIManager _uim;

	private void Start()
	{
		_uim = GameObject.Find("Canvas").GetComponent<UIManager>();
		_gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void Update()
	{
		Move();
		if (health < 0)
		{
			base.gameObject.GetComponent<PlayerMovement>().enabled = false;
			_gm.GameLost();
		}
	}

	private void Move()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		if (isGrounded && velocity.y < 0f && !CanShiftGravity)
		{
			velocity.y = -2f;
		}
		if (isGrounded && velocity.y > 0f && CanShiftGravity)
		{
			velocity.y = 2f;
		}
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		Vector3 vector = base.transform.right * axis + base.transform.forward * axis2;
		controller.Move(vector * speed * Time.deltaTime);
		if (Input.GetButtonDown("Jump") && isGrounded && !CanShiftGravity)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		else if (Input.GetButtonDown("Jump") && isGrounded && CanShiftGravity)
		{
			velocity.y = -1f * Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
		{
			if (!CanShiftGravity)
			{
				CanShiftGravity = true;
			}
			else if (CanShiftGravity)
			{
				CanShiftGravity = false;
			}
		}
		if (CanShiftGravity)
		{
			velocity.y -= gravity * Time.deltaTime;
		}
		else
		{
			velocity.y += gravity * Time.deltaTime;
		}
		controller.Move(velocity * Time.deltaTime);
		if (axis > 0f || axis2 > 0f || axis < 0f || axis2 < 0f)
		{
			anim.SetBool("canWalk", value: true);
		}
		else
		{
			anim.SetBool("canWalk", value: false);
		}
	}

	public void DamageHouse(int damage)
	{
		health -= damage;
		_uim.UpdateApartmentStabilitySlider(health);
	}
}
