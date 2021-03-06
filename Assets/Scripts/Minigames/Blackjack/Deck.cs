﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class Deck
{
    public static List<Card> deck = new List<Card>();
    public static List<Card> defaultDeck = new List<Card>();
    public static Sprite cardbackSprite;
    public static Sprite[] cardSprites;

    public static void InitialiseDeck()
    {
        cardbackSprite = Resources.Load<Sprite>(BlackjackConstants.cardbackPath);

		// Sprite names have the following format: [suit][1..9, 91..94] - so that we don't need to use .OrderBy() 
		// [suit][1..13] is not alphabetically ordered
        cardSprites = Resources.LoadAll<Sprite>(BlackjackConstants.cardsFolderPath);
        int index = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                int value = j < 10 ? j : 10;
                defaultDeck.Add(new Card(value, false, cardSprites[index]));
                index++;
            }
        }

        // Otherwise we are only copying the reference
        DeepCopyDefaultDeck(); 
    }

    private static void DeepCopyDefaultDeck()
    {
        // Can we do this without re-declaring the non-default deck?
        // Tried for loop with deck.Insert(i, defaultDeck[i]) but got weird result
        deck = new List<Card>();

        foreach (Card card in defaultDeck)
        {
            deck.Add(card);
        }
    }

    public static void ShuffleDeck()
    {
        DeepCopyDefaultDeck(); 

        for (int i = 0; i < deck.Count; i++)
        {
            int randomIndex = Random.Range(0, deck.Count);
            Card temp = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public static Card GetRandomCard()
    {
        int randomIndex = Random.Range(0, deck.Count);
        Card drawnCard = deck[randomIndex];
        deck.RemoveAt(randomIndex);
        return drawnCard;
    }
}