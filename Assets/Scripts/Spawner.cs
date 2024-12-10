using UnityEngine;
using random = UnityEngine.Random;
public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject[] spawners;
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int[] xCoords = { -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 };

        for (int yCoord = 0; yCoord < 5; yCoord++)
        {
            foreach (int xCoord in xCoords)
            {
                int ranNum = Random.Range(0, 101);
                int index = SetIndexWithGivenNumber(ranNum);

                Instantiate(spawners[index], new Vector3(xCoord, transform.position.y - yCoord, transform.position.z), Quaternion.identity);
            }
        }
        
    }

    public int SetIndexWithGivenNumber(int number)
    {
        if (number is > 0 and <= 85)
        {
            return 0;
        } 
        else if (number is > 85 and <= 95)
        {
            return 1;
        }
        else if (number > 95)
        {
            return 2;
        }
        else
        {
            return -1;
        }
    }
}
