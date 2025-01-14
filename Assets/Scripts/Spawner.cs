using UnityEngine;
using random = UnityEngine.Random;
public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject[] spawners;
    [SerializeField] Transform spawnersParent;
    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        int[] xCoords = { -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 };

        for (int yCoord = 0; yCoord < 5; yCoord++)
        {
            foreach (int xCoord in xCoords)
            {
                int ranNum = Random.Range(0, 101);
                int index = SetIndexWithGivenNumber(ranNum);
                
                

                Instantiate(spawners[index], new Vector3(xCoord, transform.position.y - yCoord, transform.position.z), new Quaternion(0f,0f,Random.rotation.z,0f), spawnersParent);
            }
        }
        
    }

    private int SetIndexWithGivenNumber(int number)
    {
        if (number is >= 0 and <= 84)
        {
            return 0;
        }
        else if (number is > 84 and <= 94)
        {
            return 1;
        }
        else if (number is > 94 and <= 97)
        {
            return 2;
        }
        else if (number > 97)
        {
            return 3;
        }
        else
        {
            Debug.Log(number);
            return -1;
        }
    }
}
