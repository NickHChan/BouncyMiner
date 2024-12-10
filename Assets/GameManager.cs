using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _ore;
    
    void Start()
    {
        SpawnFirstRow();
    }
    private void SpawnFirstRow()
    {
        int[] xCoords = { -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 };
            foreach (int xCoord in xCoords)
            {

                Instantiate(_ore, new Vector3(xCoord, transform.position.y+1, transform.position.z), Quaternion.identity);
            }
    }
        
}
