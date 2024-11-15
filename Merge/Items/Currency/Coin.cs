using System.Collections.Generic;
using Data;
using Merge.Items.ItemEventInterfaces;
using UnityEngine;

namespace Merge.Items
{
    public class Coin : Currency
    {
        protected override void UseItem()
        {
            //해당 위치에는 코인 증가로직이 있었습니다.
            //또한 파티클 효과를 실행하는 코드가 있었습니다.
        }
    }
}