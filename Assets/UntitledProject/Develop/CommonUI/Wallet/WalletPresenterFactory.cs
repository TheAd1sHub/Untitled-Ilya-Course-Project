using Assets.UntitledProject.Develop.CommonServices.ConfigsManagement;
using Assets.UntitledProject.Develop.CommonServices.Wallet;
using Assets.UntitledProject.Develop.DI;

namespace Assets.UntitledProject.Develop.CommonUI.Wallet
{
	public sealed class WalletPresenterFactory
	{
		private WalletService _walletService;
		private ConfigsProviderService _configsProviderService;

		public WalletPresenterFactory(DIContainer container)
		{
			_walletService = container.Resolve<WalletService>();
			_configsProviderService = container.Resolve<ConfigsProviderService>();
		}

        public WalletPresenterFactory(WalletService walletService, ConfigsProviderService configsProviderService)
        {
			_walletService = walletService;
			_configsProviderService = configsProviderService;
		}

        public WalletPresenter CreateWalletPresenter(IconsWithTextListView view)
			=> new WalletPresenter(_walletService, view, this);

		public CurrencyPresenter CreateCurrencyPresenter(IconWithText view, CurrencyType currencyType)
			=> new CurrencyPresenter(_walletService.GetCurrencyAmount(currencyType), currencyType, view, _configsProviderService.CurrencyIconsConfig);
	}
}
