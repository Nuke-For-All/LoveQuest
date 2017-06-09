using UnityEngine;
using System.Collections;

public class Portal:PortalEntity { 

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
    PortalBehaviours portalBehaviours;

    Portal()
    {
        portalBehaviours = new PortalBehaviours();
        if (moveNegativeDirectionFirst)
            direction *=-1;
	}
    void Start()
    {
        initialPosition = rb.position;
    }
    void FixedUpdate () {
        portalBehaviours.RotationMove(rb,rotationSpeed);
        if (isHorizontalMovement)
        {
            canMove = true;
            portalBehaviours.HorizontalMovement(direction,horizontalDistance);
        }
        if (isVerticalMovement)
        {
            canMove = true;
            portalBehaviours.VerticalMovement(direction,verticalDistance);
        }
        if (canMove)
        {
            portalBehaviours.Movement(rb,initialPosition);
        }
	}



}
