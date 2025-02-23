using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab; // Prefab for the card
    public Transform[] cardSlots; // Array of slots where cards will be spawned
    private List<GameObject> currentCards = new List<GameObject>(); // List of currently active cards
    private Sprite[] cardSprites; // Array to hold all available card sprites

    void Start()
    {
        // Load all sprites from the "Cards" folder in Prefabs/Resources
        cardSprites = Resources.LoadAll<Sprite>("Cards");

        if (cardSprites.Length == 0)
        {
            Debug.LogError("No sprites found in the 'Cards' folder. Please add some sprites.");
        }

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
        // Instantiate a new card at the given slot position
        GameObject newCard = Instantiate(cardPrefab, slot.position, Quaternion.identity);

        // Get the SpriteRenderer component of the card
        SpriteRenderer spriteRenderer = newCard.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && cardSprites.Length > 0)
        {
            // Randomly select a sprite from the loaded sprites
            int randomIndex = Random.Range(0, cardSprites.Length);
            spriteRenderer.sprite = cardSprites[randomIndex];
        }
        else
        {
            Debug.LogError("SpriteRenderer is missing or no sprites are available.");
        }

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