using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Dawn_Of_VR 
{
    class Blackjack : MonoBehaviour 
    {
        private bool blnGame = true;
        private Dealer objDealer;
        public void main()
        {
            objDealer = new Dealer();
            if (objDealer.blnRun() == false)
            {
                Debug.LogError("Blackjack: cannot run dealer");

            }
            if(objDealer.blnTestDealAll() == false)
            {
                Debug.LogError("DealToAllFailed");
            }
        }
    }
}
