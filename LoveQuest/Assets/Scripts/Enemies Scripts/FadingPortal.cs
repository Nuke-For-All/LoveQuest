using System.Collections;
using UnityEngine;

public class FadingPortal : PortalEntity {

    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        active = true;
    }

    void Update()
    {
        CheckAbsorb();
    }

    void FixedUpdate()
    {
        pb.RotationMove(rb, rotationSpeed);

        if (anim != null)
            anim.SetBool("active", absorb);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (active && obj.tag == "Player")
        {
            absorb = true;
        }
    }
}
