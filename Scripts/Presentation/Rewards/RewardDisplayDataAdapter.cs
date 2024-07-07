﻿using System;
using IFuzeHostage.SpinWheel.Data;
using UnityEngine;

namespace IFuzeHostage.SpinWheel
{
    public class RewardDisplayDataAdapter
    {
        private readonly RewardDisplay _dispaly;
        
        public RewardDisplayDataAdapter(RewardDisplay display)
        {
            _dispaly = display;
        }
        
        public void Set(RewardData data)
        {
            if (data is CurrencyRewardData currencyData)
            {
                _dispaly.Set(data.Icon, $"x{currencyData.Count}", data.DisplayName);
            }    
            else if (data is ItemRewardData itemData)
            {
                _dispaly.Set(data.Icon, string.Empty, data.DisplayName);
            }
            else
            {
                _dispaly.Set(data.Icon, string.Empty, data.DisplayName);
            }
        }
    }
}