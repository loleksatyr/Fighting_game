using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaController : MonoBehaviour
{
    [SerializeField] Text _arenaCounter;
    [SerializeField] int _arenaCounterint = 0;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _enemyRangerPrefab;
    bool start = true;
    [SerializeField] GameObject SpawnEnemies;
    [SerializeField] public static int Enemies = 0;

    void Start()
    {
    
    }

 
    void Update()
    {
        _arenaCounter.text = "Waves: " + _arenaCounterint.ToString();

        if (start) {
            for (int i = 0; i < _arenaCounterint + 4; i++) {
                GameObject.Instantiate(_enemyPrefab, SpawnEnemies.transform.position, Quaternion.identity);
                Debug.Log(_enemyPrefab.transform.position);
                Debug.Log("Enemy");
                Enemies++;
            }
            for (int i = 0; i < _arenaCounterint; i++) {
                GameObject.Instantiate(_enemyRangerPrefab, SpawnEnemies.transform.position, Quaternion.identity);
                Enemies++;
            }
            start = false;
        }
        if (Enemies == 0) {
            start = true;
            _arenaCounterint++;
        }



    }
}
