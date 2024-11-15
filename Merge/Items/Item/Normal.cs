using System;
using System.Collections.Generic;
using Data;
using DG.Tweening;
using Merge.Items.ItemEventInterfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Merge.Items
{
    /// <summary>
    /// 기본 아이템 클래스
    /// </summary>
    public class Normal : BaseItem,ISelectItemHandler,IClickActionButtonHandler,IDropOtherItemHandler,IClickItemHandler,IMergedHandler,IMergeHandler
    {
        public override void Init(ItemData itemData,int remainTime,bool isActiveItem=true,GameManager game = null)
        {
            //베이스 아이템을 초기화하는 메서드입니다.
        }

        public void OnSelectItem()
        {
           //선택했을때 로직입니다.
        }
        public void WebReleaseWithGem()
        {
            Managers.Game.Gem -= ItemData.gem;
            ReleaseWeb();
        }

        public void ReleaseWeb()
        {
            //아이템을 파괴할때는 게임매니저에서 전용 함수를 호출하여 아이템을 Pool에 반환하고 게임데이터를 저장합니다.
            MergeEventHandler.Game.DestroyItem(this);
            //아이템을 생성할때도 게임매니저에서 전용 함수를 호출하여 Pool에서 아이템을 가져온 후 게임데이터를 저장합니다.
            //이 때 생성된 아이템의 Init 메서드를 호출하여 초기화 해주었습니다.
            var item = MergeEventHandler.Game.GenerateItemOnGrid(ItemData,MergeEventHandler.OriginGrid,60);
            ReleaseBoxFromWeb();
        }

        public void OnClickActionButton()
        {
            //상호작용 버튼을 누를때 호출되는 이벤트함수입니다.

        }

        public void OnDropOtherItem(BaseItem otherItem)
        {
            //다른 아이템을 이 아이템에 드랍했을때 호출되는 이벤트함수입니다.
        }

        public void OnClickItem()
        {
            // Debug.Log("aaa");
        }

        public void OnMerge(BaseItem mergedItem)
        {
            //머지를 성공했을때 발생하는 이벤트함수입니다.
            //머지를 성공했을때 특정한 조건 하에서 랜덤으로 방해블럭인(Bubble)을 생성하도록하는 로직이 있었습니다.
            if (특정한 조건)
            {
                if (global::Utils.GetRandom(특정한 랜덤값))
                {
                    if (MergeEventHandler.Game.GenerateItemOnRandomGrid(mergedItem.ItemData,
                            mergedItem.gameObject.transform.position,60,typeof(Bubble)))
                        Logging.Log("버블 생성 성공");
                    else
                        Logging.Log("버블 생성 실패 / 남은 그리드 없음");
                }
            }
        }

        public void OnMerged(BaseItem mergedItem)
        {
            Debug.Log("OnMerged");
            Debug.Log(MergeEventHandler.IsActivatedItem);
            if (MergeEventHandler.IsActivatedItem == false)
            {
                ReleaseBoxFromWeb();
            }
        }

        private void ReleaseBoxFromWeb()
        {
          
        }
    }
}