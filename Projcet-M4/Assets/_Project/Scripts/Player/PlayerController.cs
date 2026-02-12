using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    private Rigidbody rb;
    private Camera cam;

    [Header("Parametres")]
    [Header("Speed")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float airSpeed;



    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxNumJump;

    [SerializeField] private float speedRotation;

    [Header("CurrentValue")]
    private int numJump;
    private float currentSpeed;


    [Header("Input")]
    private float horizontal;
    private float vertical;
    private bool jump;
    private bool run;


    [Header("newVelocity and Direction")]
    private Vector3 velocity;
    private Vector3 direction;
    private Vector3 lastVelocity;

    [Header("CheckGround")]
    [SerializeField] private Transform checkerGround;
    [SerializeField] private float radiusChecker;
    [SerializeField] private LayerMask ground;
    private bool isGrounded = false;





    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        numJump = 1;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(checkerGround.position, radiusChecker, ground);

        GetInput();
        CalculateVelocity();
        IsGrounded();




    }
    private void FixedUpdate()
    {
        Jump();
        rb.velocity = velocity;

        if (direction != Vector3.zero) CalculateRotation();
    }


    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        run = Input.GetKey(KeyCode.LeftShift);
        if (run)
        {
            currentSpeed = maxSpeed;
        }
        else
        {
            currentSpeed = minSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }


    }


    private void CalculateVelocity()
    {
        direction = cam.transform.forward * vertical + cam.transform.right * horizontal;
        direction.y = 0f;
        direction.Normalize();

        velocity = new Vector3(direction.x * currentSpeed, rb.velocity.y, direction.z * currentSpeed);
    }

    private void CalculateRotation()
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion rotation = Quaternion.Lerp(rb.rotation, targetRotation, speedRotation * Time.fixedDeltaTime);
        rb.MoveRotation(rotation);
    }


    private void Jump()
    {
        if (jump && (isGrounded || numJump < maxNumJump))
        {

            velocity = new Vector3(direction.x * airSpeed, jumpForce, direction.z * airSpeed);
            lastVelocity = velocity;
            numJump++;
            jump = false;

        }

    }

    public void IsGrounded()
    {

        if (isGrounded)
        {
            numJump = 1;
            lastVelocity = velocity;
        }
        else
        {
            velocity = new Vector3(lastVelocity.x + direction.x * airSpeed, rb.velocity.y, lastVelocity.z + direction.z * airSpeed);
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(checkerGround.position, radiusChecker);
        Gizmos.color = Color.red;
    }

}

