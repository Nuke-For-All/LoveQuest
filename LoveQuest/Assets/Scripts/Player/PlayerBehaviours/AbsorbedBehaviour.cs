using System.Collections;
using UnityEngine;

public class AbsorbedBehaviour {

    private float rotationForce = 20;
    private float timer = 0;
    private Vector2 target;
    private bool active;
    public void AbsorbedByPortal(Transform target, bool active)
    {
        this.active = active;
        this.target = target.position;
    }
    public void OnAbsorbedByPortal(Rigidbody2D rb)
    {
        if (active)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.freezeRotation = false;
            rb.MoveRotation(rb.rotation + (rotationForce*-rb.gameObject.transform.localScale.x));
            timer += Time.deltaTime;
            if (timer > 1) { timer = 0; }
            Vector2 destinyPosition = new Vector2(Mathf.Lerp(rb.position.x, target.x, timer), Mathf.Lerp(rb.position.y, target.y, timer));
            rb.MovePosition(destinyPosition);
        }
    }
}
