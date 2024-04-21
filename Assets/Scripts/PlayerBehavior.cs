using UnityEngine;
using UnityEngine.Events;

public class PlayerBehavior : MonoBehaviour
{
    private float[] lanes = new float[3] { -4f, 0f, 4f };
    public float jumpForce = 1f; 
    public float moveSpeed = 5f; 
    private Rigidbody rb;
    public Canvas GameOver;
    private int _currentLane = 0;
    public float laneChangeSpeed = 5;
    public const float SENSIBILIDADE_SWIPE = 20f;
    public UnityEvent onSwipeLeft;
    public UnityEvent onSwipeRight;
    public UnityEvent onSwipeUp;
    public UnityEvent onSwipeDown;
    private Vector3 startTouchPos;
    private Vector3 endTouchPos;
    private Vector2 startEndTouch;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameOver.gameObject.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            Jump();
        }
        if(other.tag == "Floor")
        {
            Time.timeScale = 0;
            GameOver.gameObject.SetActive(true);
        }
    }

    void Jump()
    {
        rb.velocity = Vector3.up * jumpForce;
    }
    public void MoverDireita()
    {
        _currentLane++;
        if (_currentLane >= lanes.Length)
        {
            _currentLane = lanes.Length - 1;
        }
    }

    public void MoverEsquerda()
    {
        _currentLane--;
        if (_currentLane <= 0)
        {
            _currentLane = 0;
        }
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch frstTouch = Input.GetTouch(0);
            if (frstTouch.phase == TouchPhase.Began)
            {
                startTouchPos = frstTouch.position;
                endTouchPos = frstTouch.position;
            }
            if (frstTouch.phase == TouchPhase.Ended)
            {
                endTouchPos = frstTouch.position;
                startEndTouch.x = startTouchPos.x - endTouchPos.x;
                startEndTouch.y = startTouchPos.y - endTouchPos.y;

                if (startTouchPos.x < endTouchPos.x && Mathf.Abs(startEndTouch.x) > 500f && Mathf.Abs(startEndTouch.y) < 500f)
                {
                    MoverDireita();
                }
                if (startTouchPos.x > endTouchPos.x && Mathf.Abs(startEndTouch.x) > 500f && Mathf.Abs(startEndTouch.y) < 500f)
                {
                    MoverEsquerda();
                }
            }
        }

        float x = lanes[_currentLane];
        Vector3 newPos = rb.position;
        newPos.x = Mathf.MoveTowards(newPos.x, x, laneChangeSpeed * Time.deltaTime);
        transform.position = newPos;
    }
}







