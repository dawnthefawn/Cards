using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Dawn_Of_VR
{
    public class Dealer : MonoBehaviour
    {

        private Deck objDeck;
        private Hand objDealerHand;
        private Hand objPlayerHand;

        // Use this for initialization
       public bool blnRun() 
        {
            var deckInit = new Deck();

            if(deckInit.blnRun() == false)
            {
                Debug.Log("Dealer: objDeck.blnRun Fail");
                return false;
            }

            if(deckInit.intDeckLength != 52)
            {
                Debug.Log("Dealer, Deck not proper size: " + objDeck.intDeckLength.ToString());
                return false;
            }

            objDeck = deckInit;
            return true;

        }



        public bool blnTestDealAll()
        {
            for (int j = 51; j > 1; j--)
            {
                Card c = objDeck.objDrawCard();
                Debug.Log(c.intValue.ToString());

            }
            return true;
        }

        }

        // Update is called once per frame
    }
