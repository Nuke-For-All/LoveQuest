using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public delegate void NotifyTouching();

    static public event NotifyTouching onFloor;
    static public event NotifyTouching onAir;
    static public event NotifyTouching onWallGrab;

    public delegate void NotifyAction();

    static public event NotifyAction onJump;

	Jump jump;
	WallJump walljump;
    Movement movement;
    WallGrab wallgrab;

    private float horizontalDetectionDist;
    private float verticalDetectionDist;

    /// <summary>
    /// direccion que esta tocando
    /// </summary>
    private Vector2 touching;

	Rigidbody2D rb;
    BoxCollider2D bc;

    void Awake()
	{

		rb = GetComponent<Rigidbody2D> ();
        bc = GetComponent<BoxCollider2D>();

        jump = new Jump (transform, rb);
		walljump = new WallJump (transform, rb);
        movement = new Movement(transform, rb);
        wallgrab = new WallGrab(transform, rb);

        //Se le suma 0.1 para que el rayo salga de la box lo minimo posible
        horizontalDetectionDist = bc.size.x * (transform.lossyScale.x / 2) + 0.1f; 
        verticalDetectionDist = bc.size.y * (transform.lossyScale.y / 2) + 0.1f;
	}
	
	// Update is called once per frame
	void Update () {

		Controls ();
        
        CheckOnAir();
        CheckOnFloor();
        CheckOnWallGrab();
        CheckOnJump();

        wallgrab.SetDirection(touching);
        walljump.SetDirection(touching);
	}

	private void Controls()
	{
		if (Input.GetButtonDown("Jump")) 
        {
            jump.Execute();
            walljump.Execute();
		}

        if(Input.GetButton("Horizontal"))
        {
            movement.Execute();
            wallgrab.Execute();
        }
	}


    /// <summary>
    /// Para saber si esta tocando la direccion que se le envia
    /// </summary>
    /// <param name="direction">
    /// Ej: Vector.down para saber si esta en el piso
    /// </param>
    /// <returns>
    /// Si esta tocando o no
    /// </returns>
    private bool IsTouching(Vector2 direction)
    {
        if (direction == Vector2.down)
        {
            Vector2 firstPos = new Vector2(transform.position.x - bc.bounds.size.x / 2, transform.position.y - bc.bounds.size.y / 2);
            Vector2 secondPos = new Vector2(transform.position.x + bc.bounds.size.x / 2, transform.position.y - bc.bounds.size.y / 2);

            RaycastHit2D firstRay = Physics2D.Raycast(firstPos, Vector2.down, verticalDetectionDist, 1 << 8);
            RaycastHit2D secondRay = Physics2D.Raycast(secondPos, Vector2.down, verticalDetectionDist, 1 << 8);

            //Para pruebas
            //Debug.DrawRay(firstPos, Vector2.down, Color.green);
            //Debug.DrawRay(secondPos, Vector2.down, Color.green);

            if (firstRay.collider != null || secondRay.collider != null)
            {
                touching = Vector2.down;
                return true;
            }
        }
        else if(direction == Vector2.left)
        {
            Vector2 firstPos = new Vector2(transform.position.x - bc.bounds.size.x / 2, transform.position.y + bc.bounds.size.y / 2);
            Vector2 secondPos = new Vector2(transform.position.x - bc.bounds.size.x / 2, transform.position.y - bc.bounds.size.y / 2);

            RaycastHit2D firstRay = Physics2D.Raycast(firstPos, Vector2.left, horizontalDetectionDist, 1 << 8);
            RaycastHit2D secondRay = Physics2D.Raycast(secondPos, Vector2.left, horizontalDetectionDist, 1 << 8);

            //Para pruebas
            //Debug.DrawRay(firstPos, Vector2.left, Color.green);
            //Debug.DrawRay(secondPos, Vector2.left, Color.green);

            if (firstRay.collider != null || secondRay.collider != null)
            {
                touching = Vector2.left;
                return true;
            }
        }
        else if(direction == Vector2.right)
        {
            Vector2 firstPos = new Vector2(transform.position.x + bc.bounds.size.x / 2, transform.position.y + bc.bounds.size.y / 2);
            Vector2 secondPos = new Vector2(transform.position.x + bc.bounds.size.x / 2, transform.position.y - bc.bounds.size.y / 2);

            RaycastHit2D firstRay = Physics2D.Raycast(firstPos, Vector2.right, horizontalDetectionDist, 1 << 8);
            RaycastHit2D secondRay = Physics2D.Raycast(secondPos, Vector2.right, horizontalDetectionDist, 1 << 8);

            //Para pruebas
            //Debug.DrawRay(firstPos, Vector2.right, Color.green);
            //Debug.DrawRay(secondPos, Vector2.right, Color.green);

            if (firstRay.collider != null || secondRay.collider != null)
            {
                touching = Vector2.right;
                return true;
            }
        }
        else if(direction == Vector2.up)
        {
            Vector2 firstPos = new Vector2(transform.position.x - bc.bounds.size.x / 2, transform.position.y + bc.bounds.size.y / 2);
            Vector2 secondPos = new Vector2(transform.position.x + bc.bounds.size.x / 2, transform.position.y + bc.bounds.size.y / 2);

            RaycastHit2D firstRay = Physics2D.Raycast(firstPos, Vector2.up, verticalDetectionDist, 1 << 8);
            RaycastHit2D secondRay = Physics2D.Raycast(secondPos, Vector2.up, verticalDetectionDist, 1 << 8);

            //Para pruebas
            //Debug.DrawRay(firstPos, Vector2.up, Color.green);
            //Debug.DrawRay(secondPos, Vector2.up, Color.green);

            if (firstRay.collider != null || secondRay.collider != null)
            {
                touching = Vector2.up;
                return true;
            }
        }

        return false;
    }

    //EVENTOS

    private void CheckOnFloor()
    {
        if(IsTouching(Vector2.down))
        {
            if(onFloor != null)
            {
                onFloor();
            }
        }
    }

    private void CheckOnAir()
    {
        if(!IsTouching(Vector2.up) && !IsTouching(Vector2.down) && !IsTouching(Vector2.right) && !IsTouching(Vector2.left))
        {
            if(onAir != null)
            {
                onAir();
            }
        }
    }

    private void CheckOnWallGrab()
    {
        if(wallgrab.IsGrabbed())
        {
            if(onWallGrab != null)
            {
                onWallGrab();
            }
        }
    }

    private void CheckOnJump()
    {
        if(jump.IsOnJump())
        {
            if(onJump != null)
            {
                onJump();
            }
        }
    }


}
