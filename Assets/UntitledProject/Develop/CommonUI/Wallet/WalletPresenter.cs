using Assets.UntitledProject.Develop.CommonServices.ConfigsManagement;
using Assets.UntitledProject.Develop.CommonServices.Wallet;
using Assets.UntitledProject.Develop.Configs.Common.Wallet;
using Assets.UntitledProject.Develop.DI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UntitledProject.Develop.CommonUI.Wallet
{

	public sealed class WalletPresenter : IInitializable, IDisposable	
	{
		private WalletService _walletService;
		private WalletPresenterFactory _factory;
		private List<CurrencyPresenter> _currenciesPresenters = new();

		private IconsWithTextListView _view;

		public WalletPresenter(
			WalletService walletService,
			IconsWithTextListView view,
			WalletPresenterFactory factory)
		{
			_walletService = walletService;
			_view = view;
			_factory = factory;
		}

		public void Initialize()
		{
			foreach (CurrencyType currencyType in _walletService.AvaiableCurrencies)
			{
				IconWithText currencyView = _view.SpawnElement();

				CurrencyPresenter currencyPresenter = _factory.CreateCurrencyPresenter(currencyView, currencyType);

				currencyPresenter.Initialize();
				_currenciesPresenters.Add(currencyPresenter);
			}
		}

		public void Dispose()
		{
			foreach (CurrencyPresenter currencyPresenter in _currenciesPresenters)
			{
				_view.Remove(currencyPresenter.View);
				currencyPresenter.Dispose();
			}

			_currenciesPresenters.Clear();
		}
	}
}
