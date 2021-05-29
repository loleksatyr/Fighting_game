using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanger : MonoBehaviour
{
    [SerializeField] int MoveSpeed = 4;
    [SerializeField] Animation animRanger;
    public int helth = 1;
    public int damage = 2;
    public GameObject projectile;
    public GameObject projectilesspawner;
    [SerializeField] private float cooldown = 5;
    private float cooldownTimer;

    private GameObject player;
    void Start()
    {

    }


    void Update()
    {
        player = GameObject.Find("FPSController");
        transform.LookAt(player.transform.position);
        if (Vector3.Distance(transform.position, player.transform.position) >= 40)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            Debug.Log("Namierzam");
        }
        else if (Vector3.Distance(transform.position, player.transform.position) < 40)
        {    
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer > 0) return;
        cooldownTimer = cooldown;
        Debug.Log("atakuje");
        GameObject bullet = Instantiate(projectile, projectilesspawner.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        Destroy(bullet, 5f);
        }

        if (helth <= 0)
        {
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
