using System.Collections;
using UnityEngine;

//Ahora es un CustomBehavior
public class AbsorbedBehaviour : CustomBehavior {

    private float rotationForce = 20;
    private float timer = 0;

    public AbsorbedBehaviour(Transform p, Rigidbody2D r)
    {
        parent = p;
        rb = r;

        //observa a todos portales
        PortalEntity.onAbsorsion += Execute;
    }

    override public void Execute()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.freezeRotation = false;
        rb.MoveRotation(rb.rotation + (rotationForce * -rb.gameObject.transform.localScale.x));
        timer += Time.deltaTime;
        if (timer > 1) { timer = 0; }
        Vector2 destinyPosition = new Vector2(Mathf.Lerp(rb.position.x, parent.position.x, timer), Mathf.Lerp(rb.position.y, parent.position.y, timer));
        rb.MovePosition(destinyPosition);
    }


}
