using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CustomBehavior {

	protected Transform parent;
	protected Rigidbody2D rb;

    abstract public void Execute();

}
