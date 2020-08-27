﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeerShop.Utility
{
    public static class SD
    {
        public const string Proc_ContainerType_Create = "usp_CreateContainerType";
        public const string Proc_ContainerType_Get = "usp_GetContainerType";
        public const string Proc_ContainerType_GetAll = "usp_GetAllContainerType";
        public const string Proc_ContainerType_Update = "usp_UpdateContainerType";
        public const string Proc_ContainerType_Delete = "usp_DeleteContainerType";

        public const string Role_User_Indi = "Individual Customer";
        public const string Role_User_Comp = "Company Customer";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";


        public static double GetPriceBasedOnQuantity(double quantity, double price, double price50, double price100)
        {
            if (quantity<50)
            {
                return price;
            }
            else
            {
                if (quantity<100)
                {
                    return price50;
                }
                else
                {
                    return price100;
                }
            }
        }

        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}
