using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ore;
    [SerializeField] private Transform arena;
    [SerializeField] private GameObject containerpreFab;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject beginningContainer;
    [SerializeField] private int distanceBeforeNextSpawn;
    private int _currentPlayerLocation;
    private int _previousPlayerLocation;
    private int _nextContainerYLocation;
    
    void Start()
    {
        _previousPlayerLocation = Mathf.RoundToInt(player.transform.position.y);
        _nextContainerYLocation = Mathf.RoundToInt(beginningContainer.transform.position.y);
        SpawnFirstRow();
    }

    void Update()
    {
        _currentPlayerLocation = Mathf.RoundToInt(player.transform.position.y);
        SpawnNextRow();
    }

    private void SpawnFirstRow()
    {
        int[] xCoords = { -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 };
            foreach (int xCoord in xCoords)
            {

                Instantiate(ore, new Vector3(xCoord, transform.position.y+1, transform.position.z), Quaternion.identity, beginningContainer.transform);
            }
    }

    private void SpawnNextRow()
    {
        if (_previousPlayerLocation - _currentPlayerLocation >= distanceBeforeNextSpawn)
        {
            _previousPlayerLocation = _currentPlayerLocation;
            _nextContainerYLocation -= 5;
            Instantiate(containerpreFab, new Vector3( transform.position.x, _nextContainerYLocation, transform.position.z), Quaternion.identity, arena);
            
        }
    }

}
