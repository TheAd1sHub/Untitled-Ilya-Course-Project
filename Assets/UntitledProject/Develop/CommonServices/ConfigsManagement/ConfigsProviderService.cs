using Assets.UntitledProject.Develop.CommonServices.AssetsManagement;
using Assets.UntitledProject.Develop.Configs.Common.Wallet;

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

		public void LoadAll()
		{
			LoadStartWalletConfig();
		}

		private void LoadStartWalletConfig()
			=> StartWalletConfig = _assetLoader.LoadResource<StartWalletConfig>(ConfigsAssetsPaths.StartWalletConfigPath);
	}
}
