using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{

    [SerializeField] int MoveSpeed;
    [SerializeField] Animation animMelee;
    public int helth;
    public int damage;
    private GameObject player;
    void Start()
    {
        MoveSpeed = 4;
        helth = 2;
        damage = 1;
    }


    void Update()
    {
        player = GameObject.Find("FPSController");
        transform.LookAt(player.transform.position);
        if (Vector3.Distance(transform.position, player.transform.position) >= 3) {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }
        else if (Vector3.Distance(transform.position, player.transform.position) < 4) {
                animMelee.Play("Enemy_attack");
        }
        
        if (helth <= 0) {
            Destroy(gameObject);
            ArenaController.Enemies--;
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (Player_Controller.Oneshot)
        {
            if (col.gameObject.tag == "Attack")
            {
                helth = -1;
            }
            if (col.gameObject.tag == "PlayerBullet")
            {
                helth = -1;
                Destroy(col.gameObject);
            }
        }
        else
        {
            if (col.gameObject.tag == "Attack")
            {
                helth--;
            }
            if (col.gameObject.tag == "PlayerBullet")
            {
                helth--;
                Destroy(col.gameObject);
            }
        }

    }
   
  
  
    
}
