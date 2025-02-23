using UnityEngine;

public class CardClick : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Carta clickeada: " + gameObject.name);

        CardManager cardManager = Object.FindFirstObjectByType<CardManager>();

        if (cardManager != null)
        {
            cardManager.UseCard(gameObject);
        }
    }
}