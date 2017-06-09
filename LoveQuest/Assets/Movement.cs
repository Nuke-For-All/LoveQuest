using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CustomBehavior {

    private float direction;

	public Movement(Transform t, Rigidbody2D _rb)
    {
        parent = t;
        rb = _rb;
    }

    override public void Execute()
    {
        direction = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector2(direction, 0), ForceMode2D.Impulse);
    }
}
