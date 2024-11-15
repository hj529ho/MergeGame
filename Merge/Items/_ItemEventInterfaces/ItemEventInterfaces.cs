using UnityEngine;

namespace Merge.Items.ItemEventInterfaces
{
    /// <summary>
    /// 머지 아이템을 선택했을때
    /// </summary>
    public interface ISelectItemHandler
    {
        /// <summary>
        /// (이벤트 메소드) 머지 아이템을 선택했을 때 호출
        /// </summary>
        public void OnSelectItem();
    }
    /// <summary>
    /// 머지 아이템을 클릭했을 때
    /// </summary>
    public interface IClickItemHandler
    {
        /// <summary>
        /// (이벤트 메소드) 머지 아이템을 클릭했을 때 호출 <br/>
        /// 근데 사실 OnPointerUp 에서 실행됨
        /// </summary>
        public void OnClickItem();
    }
    /// <summary>
    /// 머지 아이템을 선택 중일때
    /// </summary>
    public interface ITickDuringSelectHandler
    {
        /// <summary>
        /// (이벤트 메소드) 머지 아이템을 선택 중일 때 업데이트 함수 실행 후 호출
        /// </summary>
        public void TickDuringSelect();
    }
    /// <summary>
    /// 머지 아이템을 드래그 중일때
    /// </summary>
    public interface IDragItemHandler
    {
        /// <summary>
        /// (이벤트 메소드) 머지 아이템을 드래그중일 때 호출
        /// </summary>
        /// <param name="position">OnDrag의 eventdata.position</param>
        public void OnDragItem(Vector2 position);
    }
    /// <summary>
    /// 머지 아이템을 길게 클릭중일 때
    /// </summary>
    public interface ILongClickItemHandler
    {
        /// <summary>
        /// (이벤트 메소드) 머지 아이템을 길게 클릭중일 때 호출
        /// </summary>
        public void OnLongClickItem();
    }
    /// <summary>
    /// 머지 아이템의 Action Button을 클릭했을 때
    /// </summary>
    public interface IClickActionButtonHandler
    {
        /// <summary>
        /// (이벤트 메소드) 머지 아이템의 Action Button을 클릭했을 때 호출
        /// </summary>
        public void OnClickActionButton();
    }
    /// <summary>
    /// 산출기의 광고버튼을 클릭했을 때
    /// </summary>
    public interface IAdsButtonHandler
    {
        /// <summary>
        /// (이벤트 메소드) 산출기의 광고버튼을 클릭했을 때 호출
        /// </summary>
        public void OnClickAdsButton();
    }
    /// <summary>
    /// 머지 아이템을 다른 아이템에 드랍했을 때
    /// </summary>
    public interface IDropOtherItemHandler
    {
        /// <summary>
        /// (이벤트 메소드) 머지 아이템을 다른 아이템에 드랍했을 때 호출
        /// </summary>
        /// <param name="otherItem">다른 아이템</param>
        public void OnDropOtherItem(BaseItem otherItem);
    }
    
    /// <summary>
    /// (미구현) 머지 아이템이 삭제되었을 때 이벤트 메소드
    /// </summary>
    public interface IDestroyItemHandler
    {
        /// <summary>
        /// (미구현)`(이벤트 메소드)머지 아이템이 삭제되었을 때 호출
        /// </summary>
        public void OnDestroyItem();
    }
    /// <summary>
    /// 다른 아이템에 의해서 머지되었을 때(보드에 있던거)
    /// </summary>
    public interface IMergedHandler
    {
        /// <summary>
        /// (이벤트 메소드)다른 아이템에 의해서 머지되었을 때 호출
        /// </summary>
        /// <param name="item">다음 레벨 아이템</param>
        public void OnMerged(BaseItem item);
    }
    /// <summary>
    /// 다른 아이템을 머지했을 때 (드래그중인 거)
    /// </summary>
    public interface IMergeHandler
    {
        /// <summary>
        /// (이벤트 메소드)다른 아이템을 머지했을 때 호출
        /// </summary>
        /// <param name="mergedItem">다음 레벨 아이템</param>
        public void OnMerge(BaseItem mergedItem);
    }
    /// <summary>
    /// 아이템을 놓았을때 맨 처음에 발생하는 이벤트
    /// </summary>
    public interface IDropItemHandler
    {
        /// <summary>
        /// (이벤트 메소드)아이템을 놓았을때 맨 처음에 호출
        /// </summary>
        public void OnDropItem();
    }
}