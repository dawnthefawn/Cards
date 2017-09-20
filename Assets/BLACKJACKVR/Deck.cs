using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Dawn_Of_VR
{

    public class Deck : MonoBehaviour
    {
        public int intDeckLength;
        private Card[] objDeck;
        private static System.Random random = new System.Random();
        private int index;
        

        public bool blnRun()
        {

            if (blnGenerateDeck() == false)
            {
                Debug.LogError("objFullDeck.blnGenerateDeck Failure");
                return false;
            }

            if (blnShuffleDeck() == false)
            {
                Debug.LogError("objFullDeck.blnShuffleDeck Failure");
                return false;
            }

            return true;


        }

        public Card objDrawCard(bool blnFirstTurn = false)
        {
            
            if(blnFirstTurn != true)
            {
                index = 0;
            }
            Card c;
            try
            {
                c = objDeck[index];
            }
            catch(InvalidCastException e)
            {
                Debug.LogError(e.Message);
                return null;
            }
            index++;
            return c;
        }

        private bool blnGenerateDeck()
        {
            objDeck = new Card[52];
            try
            {
                int index = 0;
                foreach (string s in new[] { "Heart", "Diamond", "Club", "Spades" })
                {
                    for (int r = 1; r < 14; r++)
                    {
                        var card = new Card();
                        if (card.blnRun(r, s) == false)
                        {
                            Debug.LogError("Could Not Generate Card");
                            return false;
                        }
                        if (card = null)
                        {
                            Debug.LogError("card is null, index: " + index.ToString());
                            return false;
                        }
                        objDeck[index] = card;
                        index++;
                    }

                }

            }
            catch(InvalidCastException e)
            {
                Debug.LogError(e.Message);
                return false;

            }

           return true;
        }

        private bool blnShuffleDeck()
        {


            if (objDeck.Length != 52)
            {
                Debug.LogError("Deck Length: " + objDeck.Length.ToString());
                return false;

            }

            int n = objDeck.Length;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int index = random.Next(i, n);
                    Card card = objDeck[index];
                    objDeck[index] = objDeck[i];
                    objDeck[i] = card;
                }
            }
            catch(InvalidCastException e)
            {
                Debug.Log(e.Message);
                return false;
            }

            intDeckLength = objDeck.Length;

            return true;

        }




    }
}