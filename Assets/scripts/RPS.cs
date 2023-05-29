using UnityEngine;

public class RPS : MonoBehaviour
{
    [SerializeField] private int rpsType;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite rockSprite;
    [SerializeField] private Sprite paperSprite;
    [SerializeField] private Sprite scissorsSprite;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        rpsType = Random.Range(0, 3);
        InitializeSprite();
    }

    private void InitializeSprite()
    {
        if (rpsType == 0)
        {
            spriteRenderer.sprite = rockSprite;
        }

        else if (rpsType == 1)
        {
            spriteRenderer.sprite = paperSprite;
        }
        else
        {
            spriteRenderer.sprite = scissorsSprite;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        int newType = other.collider.GetComponent<RPS>().rpsType;

        if (newType != rpsType)
        {
            ChangeType(newType);
        }
    }

    private void ChangeType(int newType)
    {
        if(rpsType == 0)
        {
            if(newType == 1)
            {
                spriteRenderer.sprite = paperSprite;
                rpsType = newType;
            }
        }
        else if (rpsType == 1)
        {
            if (newType == 2)
            {
                spriteRenderer.sprite = scissorsSprite;
                rpsType = newType;
            }
        }
        else
        {
            if (newType == 0)
            {
                spriteRenderer.sprite = rockSprite;
                rpsType = newType;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
