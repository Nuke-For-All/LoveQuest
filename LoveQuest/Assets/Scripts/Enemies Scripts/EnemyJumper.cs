using System.Collections;
using UnityEngine;

public class EnemyJumper : EnemyEntity {

    EnemyWalk enemyWalk;
    float timer = 0;
    float jumpDelay = 2;
    float jumpForce = 6;
    EnemyJumper()
    {
        speed = 2;
        damage = 2;
        life = 1;
        enemyWalk = new EnemyWalk();
    }
    void Update()
    {
        CheckRay();
        timer += Time.deltaTime;
        if (timer> jumpDelay)
        {
            timer = 0;
            enemyWalk.WalkJumpingMovement(rb, jumpForce);
        }
        
    }
    void FixedUpdate()
    {
        enemyWalk.WalkMovement(rb, transform, speed);

    }
    void CheckRay()
    {
        enemyWalk.PhysicsRayCheckFloor(transform);
    }
}
