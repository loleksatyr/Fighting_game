using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaController : MonoBehaviour
{
    [SerializeField] Text _arenaCounter;
    [SerializeField] int _arenaCounterint = 1;
    [SerializeField] GameObject _enemyPrefab;
    bool start = true;



    void Start()
    {
        
    }

 
    void Update()
    {
        _arenaCounter.text = "Waves: "+_arenaCounterint.ToString();
        if (start) {
            for (int i = 1; i < _arenaCounterint+4; i++) {
                GameObject.Instantiate(_enemyPrefab, new Vector3(1, 1, 0), Quaternion.identity);
            }
            start = false;
        }
        



    }
}
