using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPeelSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _bananaPrefab;
    public bool canUse = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D) && (canUse == true)) 
            BananaLauncher(-1);
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A) && (canUse == true)) 
            BananaLauncher(1);
    }
    public void BananaLauncher(int _direction)
    {
        Vector2 _spawner = new Vector2(transform.position.x + (_direction * 2f), transform.position.y);
        Instantiate(_bananaPrefab, _spawner, Quaternion.identity);
        canUse = false;
    }

}
