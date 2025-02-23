using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform[] cardSlots;

    private List<GameObject> currentCards = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Draw 4 cards
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

        //Card cardScript = newCard.GetComponent<Card>();
        //if (cardScript != null)
        //{
        //    cardScript.cardName = "Card" + Random.Range(1, 101);
        //    cardScript.value = Random.Range(1, 11);
        //}

        currentCards.Add(newCard);
    }

    public void UseCard(GameObject cardToUse)
    {
        if (currentCards.Contains(cardToUse))
        {
            Transform slot = cardToUse.transform;

            currentCards.Remove(cardToUse);
            Destroy(cardToUse);

            SpawnRandomCard(slot);
        }
    }
}
