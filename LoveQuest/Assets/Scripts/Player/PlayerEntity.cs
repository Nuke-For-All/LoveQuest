using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour {

    AbsorbedBehaviour absorbed;
    PlayerMovement playerMovement;
    Rigidbody2D rb;

    void Awake()
    {
        absorbed = new AbsorbedBehaviour();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = new PlayerMovement(rb);
    }
    void Update()
    {
        playerMovement.CheckInputs();
        playerMovement.Jump();
        playerMovement.LimitSpeed();
        playerMovement.CheckFloor();
    }
    void FixedUpdate()
    {
        playerMovement.Movement();
        absorbed.OnAbsorbedByPortal(rb);
    }

    public void AbsorbedByPortal(Transform t)
    {
        absorbed.AbsorbedByPortal(t, true);
    }
   
}
