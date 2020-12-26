using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Destroy(collision.gameObject);
            _levelLoader.LoadLevel();
        }
    }
}