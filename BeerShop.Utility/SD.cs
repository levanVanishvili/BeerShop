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
    }
}
