using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPeelSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _bananaPrefab;
    public bool canUse = false;

    void Update()
    {
        int dir = 0;
        if (GetComponent<SpriteRenderer>().flipX)
        {
            dir = -1;
        }
        else dir = 1;

        if (Input.GetKeyDown(KeyCode.Space) && (canUse == true))
            BananaLauncher(-dir);
    }
    public void BananaLauncher(int _direction)
    {
        Vector2 _spawner = new Vector2(transform.position.x + (_direction * 2f), transform.position.y+0.5f);
        Instantiate(_bananaPrefab, _spawner, Quaternion.identity);
        canUse = false;
    }

}
