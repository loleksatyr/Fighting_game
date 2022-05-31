using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArenaController : MonoBehaviour
{
    [SerializeField] Text _arenaCounter;
    [SerializeField] int _arenaCounterint;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _enemyRangerPrefab;
    bool start = true;
    [SerializeField] GameObject SpawnEnemies;
    [SerializeField] GameObject SpawnEnemiesRanged;
    [SerializeField] public static int Enemies;
    [SerializeField] GameObject Win;
    [SerializeField] GameObject _healingPrefab;


    void Start()
    {
        _arenaCounterint = 1;
        Enemies = 0;
        Win.gameObject.SetActive(false);
    }

 
    void Update()
    {
        _arenaCounter.text = "Waves: " + _arenaCounterint.ToString();

        if (start) {
            for (int i = 0; i < _arenaCounterint + 4; i++) {
                GameObject.Instantiate(_enemyPrefab, SpawnEnemies.transform.position, Quaternion.identity);
                Enemies++;
            }
            for (int i = 0; i < _arenaCounterint; i++) {
                GameObject.Instantiate(_enemyRangerPrefab, SpawnEnemiesRanged.transform.position, Quaternion.identity);
                Enemies++;
            }
            var position = new Vector3(Random.Range(-154.0f, 98.0f), 0, Random.Range(-87.0f, 155.0f));
            GameObject.Instantiate(_healingPrefab, position, Quaternion.identity);
            start = false;
        }
        if (Enemies == 0) {
            if (_arenaCounterint < 6)
            {
                start = true;
                _arenaCounterint++;
            }
            else {
                Win.SetActive(true);
                if (Input.GetKey(KeyCode.Escape)) {
                    //Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene("MainScene");

                }
            }
           
        }



    }
}
