using System;
using System.Collections.Generic;
using DG.Tweening;
using Merge.Items.ItemEventInterfaces;
using UnityEngine;

namespace Merge.Items
{
    public abstract class Skill<T> : BaseItem,IDropOtherItemHandler,IDragItemHandler,ILongClickItemHandler,IDropItemHandler where T : BaseItem
    {
        protected GameObject SpecialEffect;
        protected Sequence Sequence;
        protected bool isUseEffect = false;
        public override void Init(ItemData itemData, int remainTime, bool isActiveItem = true,GameManager game = null)
        {
            base.Init(itemData, remainTime, isActiveItem,game);
            Init();
        }

        public abstract void Init();

        public List<BaseItem> TargetList = new List<BaseItem>();
        /// <summary>
        /// 아이템 효과 메소드
        /// </summary>
        /// <param name="target">효과의 타겟</param>
        protected abstract void ItemEffect(T target);
        public void OnDropOtherItem(BaseItem otherItem)
        {
            ReleaseEffect();
            Type type = otherItem.GetType();
            //타겟 타입이 아닌 아이템에 드랍되었을때는 위치를 이동하고 리턴합니다.
            if (type != typeof(T))
            {
                Utils.MoveOut(Managers.Game.Board,MergeEventHandler,otherItem);
                return;
            }
            //그 외의 경우 아이템을 사용합니다.
            UseItem();
            return;
            void UseItem()
            {
                if (otherItem.GetType() == typeof(T))
                {
                    ItemEffect((T)otherItem);
                    return;
                }
                Utils.MoveOut(Managers.Game.Board,MergeEventHandler,otherItem);
            }
        }

        protected virtual void UseEffect()
        {
           //아이템을 사용할 수 있는 아이템의 색을 변화시키는 로직입니다.
        }

        protected virtual void ReleaseEffect()
        {
            //다시 원래대로 돌아가는 로직입니다.
        }

        public void OnDragItem(Vector2 position)
        {
            UseEffect();
        }

        public void OnLongClickItem()
        {
            UseEffect();
        }

        public void OnDropItem()
        {
            ReleaseEffect();
        }
    }
}