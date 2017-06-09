using System.Collections;
using UnityEngine;

public class EnemyEntity : MonoBehaviour {

    protected Rigidbody2D rb;
    protected float speed;
    protected float damage;
    protected float life;

	void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
	}


}
