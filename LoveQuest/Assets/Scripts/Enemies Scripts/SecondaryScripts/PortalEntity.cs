using System.Collections;
using UnityEngine;

public class PortalEntity : MonoBehaviour {

    protected Rigidbody2D rb;
    protected float rotationSpeed = 3f;
    protected Vector2 initialPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
}
