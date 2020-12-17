using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCoinsOnLevel : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPoints;

    private Transform[] _points;

    private void Awake()
    {
        _points = new Transform[_spawnPoints.childCount];
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }
    }

    private void Start()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            GameObject newGameObject = Instantiate(_template, _points[i].position, Quaternion.identity);
        }
    }
}