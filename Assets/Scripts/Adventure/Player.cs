using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Character
{   
    public Text textHeroDmg;
    public Text textLevel;
    public bool isEndGame;
    
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetFloat("Level", 0.01f);
        target = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
        if(PlayerPrefs.HasKey("Level")){
            attackDamage += PlayerPrefs.GetFloat("Level") - 0.01f;
        } else {
            PlayerPrefs.SetFloat("Level", 0.01f);
            attackDamage += PlayerPrefs.GetFloat("Level") - 0.01f;
        }

        textHeroDmg.text = "Hero Damage: " + (attackDamage * 100).ToString();    
        textLevel.text = "Level: " + (PlayerPrefs.GetFloat("Level") * 100).ToString();    
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

        if(!target) {
            if(GameObject.FindGameObjectWithTag("enemy")){
                target = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
                isEndGame = true;
            } else {
                if(isEndGame) {
                    float dmg = PlayerPrefs.GetFloat("Level");
                    dmg += 0.01f;
                    PlayerPrefs.SetFloat("Level", dmg);
                    isEndGame = false;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "enemy"){
            if(collision.gameObject.GetComponent<Enemy>().isAttacking) {
                hp -= collision.gameObject.GetComponent<Enemy>().attackDamage;            
                collision.gameObject.GetComponent<Enemy>().isAttacking = false;
                collision.gameObject.transform.position = new Vector2(collision.gameObject.GetComponent<Enemy>().posX, collision.gameObject.GetComponent<Enemy>().posY);
            }    
        }
    }
}
