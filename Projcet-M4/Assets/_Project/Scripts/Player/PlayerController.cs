using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    private Rigidbody rb;
    private Camera cam;

    [Header("Parametres")]
    [Header("Speed")]
    [SerializeField] private float speed;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJump;

    [SerializeField] private float speedRotation;

    [Header("CurrentValue")]
    private int numJump;


    [Header("Input")]
    private float horizontal;
    private float vertical;
    private bool jump;

    [Header("newVelocity and Direction")]
    private Vector3 velocity;
    private Vector3 direction;

    [Header("CheckGround")]
    [SerializeField] private Transform checkerGround;
    [SerializeField] private float radiusChecker;
    private bool isGroundend = false;

    private bool IsArrivedToGround = true;


    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        //Check if it is touching a surface
        isGroundend = Physics.CheckSphere(checkerGround.position, radiusChecker);
        IsGrounded();

        //Controller 
        GetInput();
        CalculateVelocity();


    }
    private void FixedUpdate()
    {
        Jump();
        rb.velocity = velocity;

        if (direction != Vector3.zero) CalculateRotation();

        if (transform.position.y <= 0 && IsArrivedToGround)
        {
            Debug.Log(Time.time);
            IsArrivedToGround = false;
        }

    }


    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
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

        velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
    }

    private void CalculateRotation()
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion rotation = Quaternion.Lerp(rb.rotation, targetRotation, speedRotation * Time.fixedDeltaTime);
        rb.MoveRotation(rotation);
    }

    private void Jump()
    {
        if (jump && (isGroundend || numJump < maxJump))
        {
            velocity.y = jumpForce;
            numJump++;
            jump = false;
          
        }

    }

    public void IsGrounded()
    {
        if (isGroundend)
        {
            numJump = 0;
        }
       
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(checkerGround.position, radiusChecker);
        Gizmos.color = Color.red;
    }

}

//First Version
//private void CalculateVelocity()
//{
//    _velocity = new Vector3(horizontal, 0, vertical);
//    if (_velocity.magnitude > 1) _velocity.Normalize();

//    //moltiplico per la speed singolarmente, per evitare che la gravita venga accelerata;
//    _velocity.x *= speed;
//    _velocity.y = rb.velocity.y;
//    _velocity.z *= speed;
//}

//Verifica della Velocita in diagonale

//float StartTime = 0;
//bool start = false;
//bool fin = false;
//public void CrometerSpeed()
//{

//    if (transform.position.x >= 0 && !start)
//    {
//        start = true;
//        StartTime = Time.time;
//        Debug.Log("start at " + StartTime);
//    }
//    if (transform.position.x >= 10 && !fin)
//    {
//        fin = true;
//        StartTime -= Time.time;
//        Debug.Log("ci ha messo " + StartTime);
//    }
//}