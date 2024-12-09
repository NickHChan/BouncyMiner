using UnityEngine;
using random = UnityEngine.Random;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;
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
                int index;
                switch (ranNum)
                {
                    ranNum > 0 && ranNum <= 33  => 0;
                        break;
                    ranNum > 34 && ranNum <= 66  => 1;
                    break;
                    ranNum > 67 => 2;
                        break;
                }

                Instantiate(spawners[ranNum], new Vector3(xCoord, transform.position.y - yCoord, transform.position.z), Quaternion.identity);
            }
        }


    }
}
