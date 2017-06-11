using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingData {

    private Vector2 touching = Vector2.zero;

    public TouchingData()
    {
        Character.onAir += Nothing;
        Character.onFloor += Down;
        Character.onLeft += Left;
        Character.onRight += Right;
        Character.onCeiling += Up;
    }

    private void Nothing()
    {
        touching = Vector2.zero;
    }

    private void Down()
    {
        touching = Vector2.down;
    }

    private void Left()
    {
        touching = Vector2.left;
    }

    private void Right()
    {
        touching = Vector2.right;
    }

    private void Up()
    {
        touching = Vector2.up;
    }

    public Vector2 Get()
    {
        return touching;
    }
}
