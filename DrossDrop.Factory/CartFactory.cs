﻿using System;
using DrossDrop.Data;
using DrossDrop.Data.DALs;
using DrossDrop.DataInterface;

namespace DrossDrop.Factory
{
    public static class CartFactory
    {
        public static ICartData GetInstance()
        {
            return new CartData();
        }
    }
}