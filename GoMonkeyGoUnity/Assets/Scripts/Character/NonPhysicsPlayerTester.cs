using UnityEngine;
using System.Collections;


public class NonPhysicsPlayerTester : MonoBehaviour
{
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
	public float superjumpHeight = 9f;
	public float snakejumpHeight = 6f;
	public float gorillajumpHeight = 2f;
	public float rillabodyjumpHeightRIGHT = 2f;
	public float rillaHeightRIGHT = 2f;
	public float rillabodyjumpHeightLEFT = 2f;
	public float rillaHeightLEFT = 2f;
	public float rillaHeightFEET = 2f;

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;

	private Bananabar points;
	private int currentPoints;
	private int maxPoints;
	
	private BananajumpScore jumpscore;
	private Health health;

	bool snake;
	bool gorilla;
	bool rillabodyRIGHT;
	bool rillabodyLEFT;
	bool rillaFEET;


	void Awake()
	{
		_animator = GetComponent<Animator>();
		_controller = GetComponent<CharacterController2D>();

		// listen to some events for illustration purposes
		_controller.onControllerCollidedEvent += onControllerCollider;
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
		_controller.onTriggerExitEvent += onTriggerExitEvent;

		points = GameObject.Find ("bananabar").GetComponent<Bananabar> ();
		jumpscore = GameObject.Find("jumpScore").GetComponent<BananajumpScore>();
		health = GameObject.Find("Health").GetComponent<Health> ();
	}


	#region Event Listeners

	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits cause they arent very interesting
		if( hit.normal.y == 1f )
			return;

		// logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}


	void onTriggerEnterEvent( Collider2D col )
	{
		Debug.Log( "onTriggerEnterEvent: " + col.gameObject.name );
	}


	void onTriggerExitEvent( Collider2D col )
	{
		Debug.Log( "onTriggerExitEvent: " + col.gameObject.name );
	}

	#endregion


	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{
				// grab our current _velocity to use as a base for all calculations
				_velocity = _controller.velocity;

				if (_controller.isGrounded)
						_velocity.y = 0;

				if (Input.GetKey (KeyCode.D)) {
						normalizedHorizontalSpeed = 1;
						if (transform.localScale.x < 0f)
								transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);

						if (_controller.isGrounded)
								_animator.Play (Animator.StringToHash ("Run"));
				} else if (Input.GetKey (KeyCode.A)) {
						normalizedHorizontalSpeed = -1;
						if (transform.localScale.x > 0f)
								transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);

						if (_controller.isGrounded)
								_animator.Play (Animator.StringToHash ("Run"));
				} else {
						normalizedHorizontalSpeed = 0;

						if (_controller.isGrounded)
								_animator.Play (Animator.StringToHash ("Idle"));
				}


				// we can only jump whilst grounded
				if (_controller.isGrounded && Input.GetKeyDown (KeyCode.Space)) {
						_velocity.y = Mathf.Sqrt (2f * jumpHeight * -gravity);
						_animator.Play (Animator.StringToHash ("Jump"));
				}
				// bananajump
		
				if (jumpscore.jumpscore >= 10 && Input.GetKeyDown (KeyCode.E)) {
						_velocity.y = Mathf.Sqrt (2f * superjumpHeight * -gravity);
						_animator.Play (Animator.StringToHash ("Jump"));
			
						jumpscore.jumpscore = 0;
			
						points.ModifyPoints (-1000);
				}
				if (snake) {
						_velocity.y = Mathf.Sqrt (2f * snakejumpHeight * -gravity);
						_animator.Play (Animator.StringToHash ("Jump"));
						snake = false;
				}
				if (gorilla) {
						_velocity.y = Mathf.Sqrt (2f * gorillajumpHeight * -gravity);
						_animator.Play (Animator.StringToHash ("Jump"));
						gorilla = false;
				}
				if (rillabodyRIGHT) {
								_velocity.y = Mathf.Sqrt (2f * rillabodyjumpHeightRIGHT * -gravity);
								_velocity.x = Mathf.Sqrt (2f * rillaHeightRIGHT * -gravity);
								_animator.Play (Animator.StringToHash ("Jump"));
								rillabodyRIGHT = false;
						}
				if (rillabodyLEFT) {
						_velocity.y = Mathf.Sqrt (2f * rillabodyjumpHeightLEFT * -gravity);
						_velocity.x = -Mathf.Sqrt (2f * rillaHeightLEFT * -gravity);
						_animator.Play (Animator.StringToHash ("Jump"));
						rillabodyLEFT = false;
						}

		if (rillaFEET) {
			_velocity.y = -Mathf.Sqrt (2f * rillaHeightFEET * -gravity);
			_animator.Play (Animator.StringToHash ("SuperJump"));
			rillaFEET = false;
		}
						// apply horizontal speed smoothing it
						var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
						_velocity.x = Mathf.Lerp (_velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor);

						// apply gravity before moving
						_velocity.y += gravity * Time.deltaTime;

						_controller.move (_velocity * Time.deltaTime);


	
				
		}
	void OnTriggerEnter2D (Collider2D other)
	{ if (other.tag == "Snake")
						snake = true;
	
	 if(other.tag == "Gorilla")
						gorilla = true;

	if(other.tag == "rillabodyLEFT")
						rillabodyLEFT = true;



	if(other.tag == "rillabodyLEFT")
			health.ModifyHealth(-10);



	if(other.tag == "rillabodyRIGHT")
			rillabodyRIGHT = true;

	if(other.tag == "rillabodyRIGHT")
			health.ModifyHealth(-10);

		if(other.tag == "rillaFEET")
			rillaFEET = true;
		
		if(other.tag == "rillaFEET")
			health.ModifyHealth(-10);
	
			

	}

}

		
		
		
		
	

