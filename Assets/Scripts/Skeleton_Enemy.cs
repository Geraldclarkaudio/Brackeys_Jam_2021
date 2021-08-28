using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Enemy : Enemy
{
    // Start is called before the first frame update
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();    
    }

    public override void Death()
    {
        base.Death();
    }
}
