using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] int MoveSpeed = 4;
    [SerializeField] Animation animMelee;
    public int Damage = 1;
    public int Health = 2;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.LookAt(Player.transform);
        if (Vector3.Distance(transform.position, Player.transform.position) >= 3f) {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        
        if (Vector3.Distance(transform.position, Player.transform.position) <= 3f) {
            animMelee.Play("Enemy_attack");
        }
        if (Health <= 0) {
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Attack")
        {
            Health--;
        }
      
    }
    
}
