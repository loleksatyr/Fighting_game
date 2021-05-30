using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanger : MonoBehaviour
{
    [SerializeField] int MoveSpeed;
    [SerializeField] Animation animRanger;
    public int helth;
    public int damage;
    public GameObject projectile;
    public GameObject projectilesspawner;
    [SerializeField] private float cooldown;
    private float cooldownTimer;

    private GameObject player;
    void Start()
    {
        MoveSpeed = 4;
        helth = 1;
        damage = 2;
        cooldown = 5;
    }


    void Update()
    {
        player = GameObject.Find("FPSController");
        transform.LookAt(player.transform.position);
        if (Vector3.Distance(transform.position, player.transform.position) >= 80)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            Debug.Log("Namierzam");
        }
        else if (Vector3.Distance(transform.position, player.transform.position) < 80)
        {
        transform.position -= transform.forward * MoveSpeed * Time.deltaTime;
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
