using UnityEngine;

public class Unstuck : MonoBehaviour
{
    private Rigidbody2D _rb;

    private float _startTime;
    [SerializeField] private float restartTime;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }
    
    void Update()
    {
        CheckIfStuck();
    }

    private void CheckIfStuck()
    {
        if (_rb.linearVelocity.magnitude > 0.001f) return;
        if (Time.time - _startTime < restartTime) return;
        _rb.AddForce(Vector2.up * 500f);
        _startTime = Time.time;
        
    }
}
