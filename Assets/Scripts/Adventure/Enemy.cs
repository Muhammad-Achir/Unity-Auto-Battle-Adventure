using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    } 

    // Update is called once per frame
    protected override void Update()
    {
        localScaleBar.x = hp;
        childBar.transform.localScale = localScaleBar; 

        DecreaseAttackInterval();

        if(isAttacking) {
            Attack();
        }
    }
}
