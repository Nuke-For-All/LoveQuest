using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CustomBehavior {

    private float direction;
    private float force = 1.5f;

	public Movement(Transform p, Rigidbody2D _rb, TouchingData t)
    {
        parent = p;
        rb = _rb;
        touching = t;
    }

    override public void Execute()
    {
        direction = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector2(direction, 0) * force, ForceMode2D.Impulse);
    }
}
