using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] public float attackDamage;
    [SerializeField] protected float attackInterval;
    private float attackIntervalDefault;

    [SerializeField] protected float moveSpeed;

    public bool isAttacking;

    protected Transform target;

    protected Vector3 localScaleBar;
    protected Transform childBar;

    protected Transform positionDefault;
    public float posX, posY;

    void Awake()
    {
        attackIntervalDefault = attackInterval;
        positionDefault = GetComponent<Transform>();
        posX = positionDefault.position.x;
        posY = positionDefault.position.y;

        childBar = transform.Find("Health/bar");
        if(childBar) {
            localScaleBar = childBar.transform.localScale;
        }
    }

    protected virtual void Update() {
        // localScaleBar.x = hp;
        // childBar.transform.localScale = localScaleBar; 
    }

    protected void DecreaseAttackInterval()
    {
        if(attackInterval > 0) {
            attackInterval -= Time.deltaTime * 1;
        } else {
            attackInterval = attackIntervalDefault;
            isAttacking = true;
        }

        if(hp <= 0){
            // this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    protected void Attack() {
        if(target) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}
