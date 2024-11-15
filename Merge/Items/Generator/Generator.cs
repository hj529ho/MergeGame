using CodeStage.AntiCheat.ObscuredTypes;
using Data;
using DG.Tweening;
using Merge.Items.ItemEventInterfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Merge.Items
{
    public class Generator : BaseItem, ISelectItemHandler, IClickItemHandler, ILongClickItemHandler,
        IDropOtherItemHandler, IClickActionButtonHandler, ITickDuringSelectHandler, IAdsButtonHandler
    {
        // public int energy;
        private RectTransform _rectTransform;
        private MergeTimer _timer;
        private ObscuredInt _maxEnergy;
        private ObscuredInt _spendEnergy;
        private bool _isInit;
        private GameObject _usableEffect;
        private GameObject _specialEffect;
        private Sequence _sequence;
        private HungrySlimeText _text;

        public override void Init(ItemData itemData, int remainTime, bool isActiveItem = true, GameManager game = null)
        {

        }

        private bool isClicked;
        
        private void GenerateItem()
        {
            if (Managers.Game.Energy <= 0)
            {
                if ((object)Managers.UI.GetCurrentPopupUI() == null)
                    Managers.UI.ShowPopupUI<UI_EnergyBuyPopup>();
                return;
            }

            // 아이템 데이터에서 아이템을 랜덤으로 뽑아서 생성하는 로직입니다.
            var pickedData = Utils.WeightRandom(ItemData.itemsThemeDatas);
            if ((object)Managers.Game.GenerateItemOnRandomGrid(pickedData, transform.position, 60, null) != null)
            {
                Managers.Game.Energy -= 1;
                Managers.Game.Save();
                Managers.Sound.Play("SFX/ButtonSound.mp3");
                //아이템이 생성되었다면 에너지를 감소시키고 게임데이터를 저장합니다.
                //효과음도 재생합니다.
            }
            else if (isClicked == false)
            {
                isClicked = true;
                Managers.Toast.Toast("보드가 가득 찼습니다.");
                Managers.Sound.Play("SFX/ErrorSound.wav");
                //아니라면 토스트메시지를 띄우고 에러사운드를 재생합니다.
            }
            Managers.Game.ItemCountText =$"{ExtraData / ItemData.spendEnergy}/{ItemData.maxEnergy / ItemData.spendEnergy}";
        }

    
        public void OnSelectItem()
        {
            if (SceneManager.GetActiveScene().name == "TutorialMergeScene")
                return;

            isClicked = false;
            Managers.Game.ItemNameText = ItemData.GetName();
            Managers.Game.ItemLevelText = $"Lv.{ItemData.level}";
            if (!ItemData.isMaxLevel)
                Managers.Game.FlavorText = Managers.Localization.GetString("다음 아이템으로 합성 가능", "FlavorTextTable");
            else
                Managers.Game.FlavorText = Managers.Localization.GetString("최대 레벨 달성!", "FlavorTextTable");

            Managers.Game.ItemCountText =
                $"{ExtraData / ItemData.spendEnergy}/{ItemData.maxEnergy / ItemData.spendEnergy}";

            Managers.Game.InfoAction = () => { Managers.UI.ShowPopupUI<UI_ItemInfo>().Init(ItemData); };
            if (ExtraData >= _spendEnergy)
            {
                if (Utils.IsGreatestLevelOnCollection(ItemData))
                {
                    MergeEventHandler.Game.ItemActionButtonComponent.HideButton();
                    MergeEventHandler.Game.AdsButtonComponent.HideButton();
                }
                else
                {
                    MergeEventHandler.Game.ItemActionButtonComponent.SetButton(ItemActionButton.ButtonType.TextCoin,
                        "판매", $"{ItemData.coin / 10}");
                }
            }
            else
            {
                if (Managers.CloudData.CurrentMergeAdsCount < Managers.Game.MaxMergeAdsCount)
                    MergeEventHandler.Game.AdsButtonComponent.SetButton();
                else
                    MergeEventHandler.Game.AdsButtonComponent.HideButton();
                MergeEventHandler.Game.ItemActionButtonComponent.SetButton(ItemActionButton.ButtonType.TextGem,
                    "충전", $"{ItemData.gem}");
            }
        }

        private void SellItem()
        {
            Managers.Game.Coin += ItemData.coin / 10;
            MergeEventHandler.OriginGrid.Item = null;
            MergeEventHandler.Game.DestroyItem(this);
            MergeEventHandler.Game.Save();
        }

        public void OnClickItem()
        {
            //아이템을 클릭했을때 실행되는 이벤트 함수입니다.
            GenerateItem();
        }

        public void OnLongClickItem()
        {
            //아이템을 꾹 누르는동안 실행되는 이벤트 함수입니다.
            GenerateItem();
        }

        public void OnDropOtherItem(BaseItem otherItem)
        {
            //다른 아이템에 이 아이템을 드랍했을때 자리를 바꾸는 역할을 하는 유틸함수를 호출했습니다.
            Utils.MoveOut(Managers.Game.Board, MergeEventHandler, otherItem);
        }

        public void TickDuringSelect()
        {
            //선택중일때 프레임마다 실행되는 함수입니다.
            //1초마다 변하는 데이터를 UI에 표시하기 위해서 사용되었습니다.
        }

      
    }
}