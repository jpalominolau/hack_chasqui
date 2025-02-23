using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform[] cardSlots;
    private List<GameObject> currentCards = new List<GameObject>();

    void Start()
    {
        DrawInitialCards();
    }

    void DrawInitialCards()
    {
        foreach (Transform slot in cardSlots)
        {
            SpawnRandomCard(slot);
        }
    }

    void SpawnRandomCard(Transform slot)
    {
        GameObject newCard = Instantiate(cardPrefab, slot.position, Quaternion.identity);

        AnimateIdle(newCard.transform);

        currentCards.Add(newCard);
    }

    public void UseCard(GameObject cardToUse)
    {
        if (currentCards.Contains(cardToUse))
        {
            Transform slot = FindSlotForCard(cardToUse);

            if (slot != null)
            {
                DestroyCardWithAnimation(cardToUse, slot);
            }
        }
    }

    Transform FindSlotForCard(GameObject card)
    {
        foreach (Transform slot in cardSlots)
        {
            if (Vector3.Distance(card.transform.position, slot.position) < 0.1f)
            {
                return slot;
            }
        }
        return null;
    }

    void AnimateIdle(Transform cardTransform)
    {
        float randomScale = Random.Range(1.05f, 1.15f);
        float randomDuration = Random.Range(1f, 2f);

        Tween idleTween = cardTransform.DOScale(new Vector3(0.3f, 0.3f, 0.7f), 0.74f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);

        idleTween.Play();
    }

    void DestroyCardWithAnimation(GameObject cardToDestroy, Transform slot)
    {
        DOTween.Kill(cardToDestroy.transform);

        Sequence destroySequence = DOTween.Sequence();

        destroySequence.Append(cardToDestroy.transform.DOScale(0f, 0.5f).SetEase(Ease.InBack));

        SpriteRenderer spriteRenderer = cardToDestroy.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            destroySequence.Join(spriteRenderer.DOFade(0f, 0.5f));
        }

        destroySequence.Join(cardToDestroy.transform.DOMoveY(cardToDestroy.transform.position.y + 1f, 0.5f).SetRelative());

        destroySequence.OnComplete(() =>
        {
            Debug.Log("Destroying object: " + cardToDestroy.name);

            currentCards.Remove(cardToDestroy);

            Destroy(cardToDestroy);

            SpawnRandomCard(slot);
        });
    }
}