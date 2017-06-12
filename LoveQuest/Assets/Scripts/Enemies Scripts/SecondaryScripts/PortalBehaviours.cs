using System.Collections;
using UnityEngine;

public class PortalBehaviours  {


    private float speed = 2f;
    private float xTimer = 0;
    private float yTimer = 0;
    private Vector2 newPosition;

    public void RotationMove(Rigidbody2D rb,float rotationSpeed)
    {
        if(rb != null)
        {
            rb.MoveRotation(rb.rotation + rotationSpeed);
        }
    }
    public void VerticalMovement(float direction,float verticalDistance)
    {
        yTimer += Time.deltaTime * speed;
        float yPos = Mathf.Sin(yTimer) * verticalDistance;
        newPosition.y = yPos * direction;
    }
    public void HorizontalMovement(float direction, float horizontalDistance)
    {
        xTimer += Time.deltaTime;
        float xPos = Mathf.Sin(xTimer) * horizontalDistance;
        newPosition.x = xPos * direction;
    }
    public void Movement(Rigidbody2D rb, Vector2 initialPosition)
    {
        rb.MovePosition(initialPosition + newPosition);
    }
}
