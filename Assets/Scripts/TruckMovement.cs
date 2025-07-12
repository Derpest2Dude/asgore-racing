using UnityEngine;
using UnityEngine.InputSystem;
public class TruckMovement : MonoBehaviour
{
    
    [SerializeField] InputAction yAxis;
    [SerializeField] private InputAction xAxis;
    [SerializeField] private float yAxisStrength = 1f;
    [SerializeField] private float xAxisStrength = 1f;
    public LogicScript logic;

    public SoundManager soundManager;
    
    
    private void OnEnable()
    {
        yAxis.Enable();
        xAxis.Enable();
    }
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }


    void Update()
    {
        ProcessXAxis();
        ProcessYAxis();
    }
    
    private void ProcessYAxis()
    {
        float turningInput = yAxis.ReadValue<float>();
        if (turningInput < 0)
        {
            ApplyTurning(yAxisStrength);
        }
        else if (turningInput > 0)
        {
            ApplyTurning(-yAxisStrength);
        }
    }
    
    private void ApplyTurning(float turningThisFrame)
    {
        transform.Translate(Vector2.down * turningThisFrame * Time.fixedDeltaTime);
    }
    
    private void ProcessXAxis()
    {
        float throttleInput = xAxis.ReadValue<float>();
        if (throttleInput < 0)
        {
            ApplyThrottle(xAxisStrength);
        }
        else if (throttleInput > 0)
        {
            ApplyThrottle(-xAxisStrength);
        }
    }
    
    private void ApplyThrottle(float throttleThisFrame)
    {
        transform.Translate(Vector2.left * throttleThisFrame * Time.fixedDeltaTime);
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                logic.RemoveScore(1);
                print("hit somethin bad");
                Destroy(other.gameObject);
                soundManager.PlayCrashSound();
                break;
            case "Heal":
                logic.AddScore(1);
                Destroy(other.gameObject);
                break;
        }
    }
}
