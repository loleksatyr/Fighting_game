using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    
    [SerializeField] int MoveSpeed = 4;
    [SerializeField] Animation animMelee;
    public int helth = 2;
    public int damage = 1;
    EnemiesController newEnemy;
    private GameObject player;
    void Start()
    {
        
    }


    void Update()
    {
        player = GameObject.Find("FPSController");
        transform.LookAt(player.transform.position);
        if (Vector3.Distance(transform.position, player.transform.position) >= 4) {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                Debug.Log("Namierzam");
            }
        else if (Vector3.Distance(transform.position, player.transform.position) < 4) {
                animMelee.Play("Enemy_attack");
                Debug.Log("atakuje");
            
        }
        
        if (helth <= 0) {
            Destroy(gameObject);
            ArenaController.Enemies--;
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Attack")
        {
            helth--;
        }

    }
   
  
  
    
}
