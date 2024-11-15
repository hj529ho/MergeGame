using System;
using Merge.Items.ItemEventInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Merge.Items
{
    /// <summary>
    /// 보드 위 모든 아이템의 최상위 추상클래스
    /// Awake 시점에 이벤트 등록됨
    /// </summary>
    [RequireComponent(typeof(MergeItemEventHandler))]
    public class BaseItem : MonoBehaviour
    {
        public enum Status
        {
            Close,
            UnLocking,
            Opened,
        }
        
        private MergeEventHandler _mergeEventHandler;
        // 머지 이벤트 핸들러는 유니티 기본 이벤트 핸들러들을 상속받아서 머지게임 전용 이벤트 핸들러를 동작하게 하는 클래스였습니다.
        // 모든 머지 아이템을 MergeItemEventHandler을 컴포넌트로 가지고 있었습니다.

        public MergeEventHandler MergeEventHandler
        {
            get => _mergeEventHandler;
            private set =>_mergeEventHandler=value;
        }
        [NonSerialized] public Image Image;
        [NonSerialized] public ItemData ItemData;
        public int RemainTime;

        [NonSerialized] public string ItemName;
        public int ExtraData = 0;
        [NonSerialized] public Status status = 0;

        [NonSerialized] public bool IsMergeable = true;
        // public bool IsActiveItem = true;
        protected virtual void Awake()
        {
            // Handler = GetComponent<MergeItemEventHandler>();
            _mergeEventHandler = GetComponent<MergeEventHandler>();
            Image = GetComponent<Image>();
        }

        /// <summary>
        /// 초기화
        /// </summary>
        /// <param name="itemData">아이템 데이터</param>
        /// <param name="isActiveItem"></param>
        /// <param name="remainTime"></param>
        public virtual void Init(ItemData itemData,int remainTime,bool isActiveItem=true,GameManager game = null)
        {

            //베이스 아이템을 초기화하는 메서드입니다.
            //베이스 아이템은 같은 기능을 가지더라도 아이템의 종류에 따라 다른 이미지와 데이터를 가지고있을 수 있었기 때문에 생성될때 init 메서드를 통해 초기화를 해주었습니다.
            ItemData = itemData;
            Image.sprite = ItemData.Sprite;
            transform.localScale = Vector3.one;
            MergeEventHandler.IsActivatedItem = isActiveItem;
            RemainTime = remainTime;
            MergeEventHandler.OriginGrid.Item = this;
            if (game == null)
            {
                MergeEventHandler.Game = Managers.Game;
            }
            else
            {
                MergeEventHandler.Game = game;
            }
            MergeEventHandler.MergeEffectGameObject.SetActive(false);
            MergeEventHandler.IsInteractable = true;
            MergeEventHandler.CheckBackGround.SetActive(false);
        }
    }
}