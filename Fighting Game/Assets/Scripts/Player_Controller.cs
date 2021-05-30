using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] Animation animRight;
    [SerializeField] Animation animLeft;
    public int Health;
    [SerializeField] Text _healthText;
    public static GameObject Player;
    public GameObject projectile;
    public GameObject projectilesspawner;
    [SerializeField] GameObject diescreen;
    public static bool live;
    public bool immiune;
    public static bool Oneshot;
    [SerializeField] Text _DamageText;
    [SerializeField] Text _ImmiuneText;

    void Start()
    {
        diescreen.gameObject.SetActive(false);
        live = true;
        Health = 10;
        immiune = false;
        Oneshot = false;
        _DamageText.gameObject.SetActive(Oneshot);
        _ImmiuneText.gameObject.SetActive(immiune);
    }


    void Update()
    {
        _DamageText.gameObject.SetActive(Oneshot);
        _ImmiuneText.gameObject.SetActive(immiune);
        if (live)
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
            if (Health <= 0)
            {
                live = false;
                diescreen.gameObject.SetActive(true);
                Invoke("ReloadScene",3f);
            }
            if (Input.GetKeyDown(KeyCode.X)) {
                immiune = !immiune;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Health = 0;
            }
            if (Input.GetKeyDown(KeyCode.C)){

                Oneshot = !Oneshot;
            }


        }
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (immiune == false)
        {
            if (col.gameObject.tag == "EnemyAttack")
            {
                Health--;
            }
            if (col.gameObject.tag == "EnemyBullet")
            {
                Health = Health -2;
                Destroy(col.gameObject);
            }
        }
        else {

            if (col.gameObject.tag == "EnemyBullet")
            {
                Destroy(col.gameObject);
            }


        }
        if (col.gameObject.tag == "Health")
        {
            Health = Health + 5;
            Destroy(col.gameObject);
        }
    }
    public void Shot() {
        GameObject bullet = Instantiate(projectile, projectilesspawner.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        Destroy(bullet, 5f);
    }
    public void ReloadScene() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
 


