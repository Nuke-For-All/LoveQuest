using System.Collections;
using UnityEngine;
public class EnemyWalker : EnemyEntity {

    public bool MoveToContact = false;
    EnemyWalk enemyWalk;

	EnemyWalker()
    {
        speed = 2;
        damage = 2;
        life = 1;
        enemyWalk = new EnemyWalk();
    }

    void Update()
    {
        CheckRay();
    }
    void FixedUpdate()
    {
        enemyWalk.WalkMovement(rb,transform,speed);
    }
    void CheckRay()
    {
        if (MoveToContact)
        {
            enemyWalk.PhysicsRayMoveToContact(transform);
        }
        else
        {
            enemyWalk.PhysicsRayNormal(transform);
        }
    }

}
