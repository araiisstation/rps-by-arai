using UnityEngine;

public class RPS_movementsssss : MonoBehaviour
{
    private Vector2 newPosition;

    [SerializeField] private float upBoarder;
    [SerializeField] private float downBoarder;
    [SerializeField] private float leftBoarder;
    [SerializeField] private float rightBoarder;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;

        newPosition = transform.position;

        CalculateScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveAround();
    }

    private void MoveAround()
    {
        newPosition = newPosition + new Vector2( (float) Random.Range(-1, 2 ) / 35, (float) Random.Range(-1, 2 ) / 35);
        newPosition = new Vector2(Mathf.Clamp(newPosition.x, leftBoarder, rightBoarder), Mathf.Clamp(newPosition.y, downBoarder, upBoarder));
        transform.position = newPosition;
    }

    private void CalculateScreen()
    {
        Vector3 screenDimentions = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, 0));

        upBoarder = screenDimentions.y;
        downBoarder = -screenDimentions.y;
        leftBoarder = -screenDimentions.x;
        rightBoarder = screenDimentions.x;
    }
}
