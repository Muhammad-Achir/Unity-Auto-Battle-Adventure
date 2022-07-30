using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player"){
            if(collision.gameObject.GetComponent<Player>().isAttacking) {
                hp -= (collision.gameObject.GetComponent<Player>().attackDamage * 100 / 30);        
                collision.gameObject.GetComponent<Player>().isAttacking = false;
                collision.gameObject.transform.position = new Vector2(collision.gameObject.GetComponent<Player>().posX, collision.gameObject.GetComponent<Player>().posY);
            }
        }
    }
}
