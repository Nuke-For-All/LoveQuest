using System.Collections;
using UnityEngine;

public class PortalElectricity : PortalEntity {

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckAbsorb();
    }

    void FixedUpdate()
    {
        pb.RotationMove(rb, rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (active && obj.tag == "Player")
        {
            absorb = true;
        }
    }
}
