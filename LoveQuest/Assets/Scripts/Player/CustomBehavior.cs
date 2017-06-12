using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CustomBehavior {

	protected Transform parent;
	protected Rigidbody2D rb;
    protected TouchingData touching;
    protected bool active = false;

    abstract public void Execute();

    protected void Lock()
    {
        active = false;
    }

    protected void Unlock()
    {
        active = true;
    }
}
