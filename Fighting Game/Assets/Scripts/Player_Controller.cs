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
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "EnemyAttack") {
            Health--;
        }
    }
    public void Shot() { 
    
    }
}
 


