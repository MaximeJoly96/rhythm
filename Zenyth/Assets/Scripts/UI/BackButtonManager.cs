namespace Zenyth.UI
{
    public class BackButtonManager : ScreenManager
    {
        #region Methods
        public override void Init()
        {
            Hide(true);
            gameObject.SetActive(false);
        }

        public void ButtonClicked()
        {
            GameManager.BackButtonClicked();
            _ambianceManager.PlayValidation();
        }
        #endregion
    }
}
