using UnityEngine;
using System.Collections; // for IEnumerator
using DG.Tweening;

public class AnimateCard : MonoBehaviour
{
    public Tween idleCard;

    void Start()
    {
            float randomScale = Random.Range(1.05f, 1.15f);
            float randomDuration = Random.Range(1f, 2f);
            idleCard =
         transform.DOScale(new Vector3(0.3f, 0.3f, 0.7f), 0.74f)
             .SetLoops(-1, LoopType.Yoyo)
             .SetEase(Ease.InOutSine);
        idleCard.Play();
    }

    public void DestroyAnimation()
    {
        if (idleCard != null)
        {
            idleCard.Kill();
        }

        Sequence destroySequence = DOTween.Sequence();

        destroySequence.Append(transform.DOScale(0f, 0.5f).SetEase(Ease.InBack));

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        if (spriteRenderer != null)
        {
            destroySequence.Join(spriteRenderer.DOFade(0f, 0.5f));
        }
        else if (canvasGroup != null)
        {
            destroySequence.Join(canvasGroup.DOFade(0f, 0.5f));
        }

        destroySequence.Join(transform.DOMoveY(transform.position.y + 1f, 0.5f).SetRelative());

        destroySequence.OnComplete(() =>
        {
            Debug.Log("Destroying object: " + gameObject.name);
            Destroy(gameObject);
        });
    }

    void Update()
    {

    }
}
