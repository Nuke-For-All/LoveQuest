using System.Collections;
using UnityEngine;
public class EnemyWalk  {

    Vector2 plusPositionNormal = new Vector2(0.5f, -0.5f);
    Vector2 plusPositionToContact = new Vector2(0.5f, 0);
    Vector3 localScale;
    Vector2 movePosition;
    bool walking = false;
    int layer = 1<<8;
    float rayDistanceNormal = 1.2f;
    float rayDistanceToContact = .6f;

    #region JumperRegion
    float rayDistanceToCheckFloor = 2.5f;
    Vector2 plusPositionToCheckFloor = new Vector2(0.2f, -1f);
    #endregion

    public void PhysicsRayNormal(Transform t)
    {
        Vector2 finalDirection = new Vector2(plusPositionNormal.x * t.localScale.x, plusPositionNormal.y);
        walking = Physics2D.Raycast(t.position, t.TransformDirection(finalDirection), rayDistanceNormal, layer);
        //Debug.DrawRay(t.position, t.TransformDirection(finalDirection) * rayDistanceNormal, Color.green);
        //Debug.Log(walking);
    }
    public void PhysicsRayMoveToContact(Transform t)
    {
        Vector2 finalDirection = new Vector2(plusPositionToContact.x * t.localScale.x, plusPositionToContact.y);
        walking = !Physics2D.Raycast(t.position, t.TransformDirection(finalDirection), rayDistanceToContact, layer);
        //Debug.DrawRay(t.position, t.TransformDirection(finalDirection) * rayDistanceToContact, Color.green);
        //Debug.Log(walking);
    }
    public void PhysicsRayCheckFloor(Transform t)
    {
        Vector2 finalDirection = new Vector2(plusPositionToCheckFloor.x * t.localScale.x, plusPositionToCheckFloor.y);
        walking = Physics2D.Raycast(t.position, t.TransformDirection(finalDirection), rayDistanceToCheckFloor, layer);
        //Debug.DrawRay(t.position, t.TransformDirection(finalDirection)* rayDistanceToCheckFloor, Color.green);
        //Debug.Log(walking);
    }
    public void WalkMovement(Rigidbody2D rb,Transform t,float spd)
    {
        if (walking)
        {
            movePosition = rb.velocity;
            movePosition.x = spd*t.localScale.x;
            rb.velocity = movePosition;
        }
        else
        {
            if (movePosition.x!=0)
            {
                localScale = t.localScale;
                localScale.x *= -1;
                t.localScale = localScale;
            }
            movePosition.x = 0;
            rb.velocity = new Vector2(movePosition.x, rb.velocity.y);
        }

    }
    public void WalkJumpingMovement(Rigidbody2D rb,float jumpForce)
    {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
