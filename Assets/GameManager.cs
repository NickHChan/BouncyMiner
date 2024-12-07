using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject currentPiece;
    [SerializeField] private float pieceFallSpeed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        if (currentPiece)
        {
            currentPiece.transform.position = new Vector3(currentPiece.transform.position.x, currentPiece.transform.position.y - 1 * Time.deltaTime, currentPiece.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(Time.deltaTime);
            currentPiece.transform.position = new Vector3(currentPiece.transform.position.x, currentPiece.transform.position.y - pieceFallSpeed, currentPiece.transform.position.z);
        }
    }
}
