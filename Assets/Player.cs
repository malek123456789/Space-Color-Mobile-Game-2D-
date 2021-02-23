using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    
    public float jumpForce = 10f;

    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;

    public string currentColor;

    public Sprite rocketBlue;
    public Sprite rocketYellow;
    public Sprite rocketGreen;
    public Sprite rocketRed;

    private void Start()
    {
        SetRandomColor();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
        }

    }

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
                return;
        }


        if (col.tag != currentColor)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
            
        switch (index)
        {   
            case 0:
                currentColor = "Cyan";
                spriteRenderer.sprite = rocketBlue;
                break;
            case 1:
                currentColor = "Yellow";
                spriteRenderer.sprite = rocketYellow;
                break;
            case 2:
                currentColor = "Magenta";
                spriteRenderer.sprite = rocketGreen;
                break;
            case 3:
                currentColor = "Pink";
                spriteRenderer.sprite = rocketRed;
                break;
        }
    }
}
