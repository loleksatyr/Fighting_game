using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] Animation animRight;
    [SerializeField] Animation animLeft;
    public int Health = 10;
    [SerializeField] Text _healthText;
    public static GameObject Player;
    public GameObject projectile;
    public GameObject projectilesspawner;

    void Start()
    {
        
    }


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            animRight.Play("RightAttack");
        }
        if (Input.GetMouseButtonDown(1))
        {
            animLeft.Play("Leftshot");
            Shot();
        }
        _healthText.text = Health.ToString();
        if (Health <= 0) { 
        
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "EnemyAttack") {
            Health--;
        }
    }
    public void Shot() {
        GameObject bullet = Instantiate(projectile, projectilesspawner.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        Destroy(bullet, 5f);
    }

}
 


