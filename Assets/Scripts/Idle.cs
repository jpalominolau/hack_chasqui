using UnityEngine;
using DG.Tweening;

public class Idle : MonoBehaviour
{
    //  public Tween idleTween; // for retreievem memory back
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomScale = Random.Range(1.05f, 1.15f);
        float randomDuration = Random.Range(1f, 2f);

        Tween idle =
         transform.DOScale(new Vector3(0.3f, 0.3f, 0.7f), 0.74f)
             .SetLoops(-1, LoopType.Yoyo)
             .SetEase(Ease.InOutSine);
        idle.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
