using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float speed = 2f;
    private Transform bg1;
    private Transform bg2;
    private float bgWidth;

    void Start() {
        bg1 = transform.Find("Red");
        bg2 = transform.Find("Blue");

        if (bg1 != null) {
            bgWidth = bg1.GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    void Update()
    {
        MoveBackground(bg1);
        MoveBackground(bg2);

        ResetPosition(bg1);
        ResetPosition(bg2);
    }

    void MoveBackground(Transform background) {
        background.position += Vector3.right * speed * Time.deltaTime;
    }

    void ResetPosition(Transform background) {
        if (background.position.x >= bgWidth) {
            background.position += Vector3.left * bgWidth * 2;
        }
    }
}
