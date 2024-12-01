using Assets.UntitledProject.Develop.CommonServices.AssetsManagement;
using Assets.UntitledProject.Develop.Configs.Common.Wallet;
using Assets.UntitledProject.Develop.Configs.Gameplay;

namespace Assets.UntitledProject.Develop.CommonServices.ConfigsManagement
{
	public sealed class ConfigsProviderService
	{
		private ResourcesAssetLoader _assetLoader;

		public ConfigsProviderService(ResourcesAssetLoader assetLoader)
		{
			_assetLoader = assetLoader;
		}

		public StartWalletConfig StartWalletConfig { get; private set; }
		public CurrencyIconsConfig CurrencyIconsConfig { get; private set; }
		public LevelsListConfig LevelsListConfig { get; private set; }

		public void LoadAll()
		{
			LoadStartWalletConfig();
			LoadCurrencyIconsConfig();
			LoadLevelsListConfig();
		}

		private void LoadStartWalletConfig()
			=> StartWalletConfig = _assetLoader.LoadResource<StartWalletConfig>(ConfigsAssetsPaths.StartWalletConfigPath);

		private void LoadCurrencyIconsConfig()
			=> CurrencyIconsConfig = _assetLoader.LoadResource<CurrencyIconsConfig>(ConfigsAssetsPaths.CurrencyIconsConfigPath);

		private void LoadLevelsListConfig()
			=> LevelsListConfig = _assetLoader.LoadResource<LevelsListConfig>(ConfigsAssetsPaths.LevelsListConfigPath);
	}
}
