using UnityEngine;
using System.Collections;

public class Portal : PortalEntity { 

    [Header ("Causes the movement to begin inversely")]
    public bool moveNegativeDirectionFirst = false;
    [Header("Makes the movement vertical ")]
    public bool isVerticalMovement = false;
    [Header("Makes the movement horizontal")]
    public bool isHorizontalMovement = false;
    [Range(1,3)]
    public float horizontalDistance=1;
    [Range(1, 3)]
    public float verticalDistance=1;

    private float direction = 1f;
    private bool canMove = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (moveNegativeDirectionFirst)
            direction *= -1;
        initialPosition = rb.position;
    }

    void Update()
    {
        CheckAbsorb();
    }

    void FixedUpdate () {

        pb.RotationMove(rb, rotationSpeed);

        if (isHorizontalMovement)
        {
            canMove = true;
            pb.HorizontalMovement(direction,horizontalDistance);
        }
        if (isVerticalMovement)
        {
            canMove = true;
            pb.VerticalMovement(direction, verticalDistance);
        }
        if (canMove)
        {
            pb.Movement(rb, initialPosition);
        }

        active = !active;
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (active && obj.tag == "Player")
        {
            Debug.Log("hola");
            absorb = true;
        }
    }
    
}
