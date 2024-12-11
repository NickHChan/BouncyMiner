using System;
using TMPro;
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
    [SerializeField] private TextMeshProUGUI displayPlayerScore;
    private int _currentPlayerLocation;
    private int _previousPlayerLocation;
    private int _nextContainerYLocation;
    private int _spawnedContainers = 0;
    
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
        SetPlayerScore();
        RemovePassedContainers();
    }

    private void OnApplicationQuit()
    {
        Player.ResetPlayerScore();
        Player.ResetPlayerHealth();
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
            _spawnedContainers += 1;

        }
    }
    
    private void SetPlayerScore()
    {
        displayPlayerScore.text = Mathf.RoundToInt(Player.PlayerScoreValue()).ToString();
    }

    private void RemovePassedContainers()
    {
        if (_spawnedContainers > 3)
        {
            Destroy(arena.GetChild(0).gameObject);
            _spawnedContainers = 0;
        }
    }

}
