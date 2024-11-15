using Merge.Items.ItemEventInterfaces;
using UnityEngine;

namespace Merge.Items
{
    /// <summary>
    /// 바늘 아이템
    /// </summary>
    public class Needle : Skill<Bubble>,ISelectItemHandler
    {
        public override void Init()
        {
            //액티브된 아이템중에 상용가능한 아이템을 찾는 로직이 있었습니다.
        }
        protected override void ItemEffect(Bubble target)
        {
            //아이템 레벨에 따라 효과를 다르게 적용하는 로직입니다.
            switch (ItemData.level)
            {
                case 4:
                    if (target.ItemData.level <= 4)
                        UseNeedle();
                    else
                        Utils.MoveOut(Managers.Game.Board,MergeEventHandler,target);
                    break;
                case 5:
                    if (target.ItemData.level <= 7)
                        UseNeedle();
                    else
                        Utils.MoveOut(Managers.Game.Board,MergeEventHandler,target);
                    break;
                case 6:
                    UseNeedle();
                    break;
                default:
                    Utils.MoveOut(Managers.Game.Board,MergeEventHandler,target);
                    break;
            }
            void UseNeedle()
            {
                target.OpenActionWithoutGem();
                MergeEventHandler.OriginGrid.Item = null;
                Managers.Game.DestroyItem(this);
            }
        }

        public void OnSelectItem()
        {
            Init();
        }
    }
}