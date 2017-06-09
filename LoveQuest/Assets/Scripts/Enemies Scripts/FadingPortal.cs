using System.Collections;
using UnityEngine;

public class FadingPortal : PortalEntity {

    PortalBehaviours portalBehaviours;
    Animator anim;
    float radius = 2f;
    int layer = 1 << 9;
    bool active = false;

    FadingPortal()
    {
        portalBehaviours = new PortalBehaviours();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        CheckArea();
        if (anim!=null)
            anim.SetBool("active", active);
    }
    void FixedUpdate()
    {
        portalBehaviours.RotationMove(rb, rotationSpeed);
    }

    void CheckArea()
    {
        active = Physics2D.OverlapCircle(transform.position, radius, layer);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.SendMessage("AbsorbedByPortal", transform);
        }
    }
}
