using System;
using DG.Tweening;
using Merge.Items.ItemEventInterfaces;
using UnityEngine;

namespace Merge.Items
{
    public abstract class Currency : BaseItem, IClickItemHandler, IClickActionButtonHandler, IDropOtherItemHandler,ISelectItemHandler
    {
        public override void Init(ItemData itemData, int remainTime, bool isActiveItem = true, GameManager game = null)
        {
            base.Init(itemData, remainTime, isActiveItem,game);
        }

        protected abstract void UseItem();
        public void OnClickItem()
        {
            UseItem();
            //아이템을 더블클릭했을때의 로직입니다.
            //아이템을 사용하는 사운드, UI등 변경등의 로직이 있었고
            //재화가 바뀌었기 때문에 게임데이터를 저장하는 메서드가 실행되었습니다.

        }
        
        public void OnClickActionButton()
        {
            UseItem();
            MergeEventHandler.OriginGrid.Item = null;
            MergeEventHandler.Game.DestroyItem(this);
        }
        
        public void OnDropOtherItem(BaseItem otherItem)
        {
            //아이템을 다른 아이템에 드랍했을때 로직입니다.
            //창고에 드랍했다면 아이템을 삭제하고 창고로 보냈습니다.
        }

        public void OnSelectItem()
        {
            //아이템을 선택했을때 로직입니다.
            // 여기서는 이 아이템의 레벨, 이름, 설명을 UI에 표시하는 코드가 있었습니다.
            // 또한 상호작용 버튼의 액션을 바꿔주는 코드가 있었습니다.
        }
    }
}