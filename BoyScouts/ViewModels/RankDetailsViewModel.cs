using System;
using System.Windows;
using BoyScouts.Messages;
using BoyScouts.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.Controls;

namespace BoyScouts.ViewModels
{
    public class RankDetailsViewModel : ViewModelBase
    {
        public RankDetailsViewModel()
        {
            MessengerInstance.Register<RankSelectedMessage>(this, (message) =>
            {
                this.RankObject = message.Rank;
            });
        }

        #region RankObject property

        private Rank _rank = null;

        public Rank RankObject
        {
            get
            {
                return _rank;
            }

            set
            {
                if (_rank == value)
                {
                    return;
                }

                var oldValue = _rank;
                _rank = value;
                RaisePropertyChanged(() => this.RankObject);
            }
        }

        #endregion RankObject property

        public override void Cleanup()
        {
            this.RankObject = null;
            base.Cleanup();
        }
    }
}