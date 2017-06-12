using System.Collections;
using UnityEngine;

public class PortalEntity : MonoBehaviour {

    public delegate void Absorsion();

    static public event Absorsion onAbsorsion;

    protected Rigidbody2D rb;
    protected float rotationSpeed = 3f;
    protected Vector2 initialPosition;
    protected bool active = false;
    protected bool absorb = false;
   
    protected PortalBehaviours pb = new PortalBehaviours();

    protected void CheckAbsorb()
    {
        if (absorb && onAbsorsion != null)
        {
            onAbsorsion();
        }
    }
}
