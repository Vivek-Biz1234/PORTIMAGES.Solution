using PORTIMAGES.Application.Common.Models; 

namespace PORTIMAGES.Application.Common.Helpers
{
    public static class DropdownMappings
    {
        public static DropdownConfig Get(string key)
        {
            return key switch
            {
                "SHIPTYPE" => new DropdownConfig
                {
                    TableName = "ShipType",
                    ValueField = "ID",
                    TextField = "TypeName",
                    OrderBy = "TypeName"
                },
                "SHIPPING" => new DropdownConfig
                {
                    TableName = "ShippingMaster",
                    ValueField = "ID",
                    TextField = "ShippingName",
                    OrderBy = "ShippingName"
                },
                "SHIP" => new DropdownConfig
                {
                    TableName = "ShipMaster",
                    ValueField = "ID",
                    TextField = "ShipName",
                    OrderBy = "ShipName"
                },
                "PORT" => new DropdownConfig
                {
                    TableName = "PortMaster",
                    ValueField = "ID",
                    TextField = "PortName",
                    OrderBy = "PortName"
                },

                "TERMINAL" => new DropdownConfig
                {
                    TableName = "TerminalMaster",
                    ValueField = "ID",
                    TextField = "TerminalName",
                    FilterField = "PortID",
                    OrderBy = "TerminalName"
                },
                "COUNTRY" => new DropdownConfig
                {
                    TableName = "CountryMaster",
                    ValueField = "ID",
                    TextField = "CountryName",
                    FilterField = "ID",
                    OrderBy = "CountryName"
                },
                "SHIPUSE" => new DropdownConfig
                {
                    TableName = "ShipUse",
                    ValueField = "ID",
                    TextField = "UseType",
                    FilterField = "ID",
                    OrderBy = "UseType"
                },
                "CATEGORY" => new DropdownConfig
                {
                    TableName = "Category",
                    ValueField = "ID",
                    TextField = "CategoryName",
                    FilterField = "ID",
                    OrderBy = "CategoryName"
                },
                "MAKER" => new DropdownConfig
                {
                    TableName = "Makers",
                    ValueField = "ID",
                    TextField = "MakerName",
                    FilterField = "ID",
                    OrderBy = "MakerName"
                },
                "MODEL" => new DropdownConfig
                {
                    TableName = "Models",
                    ValueField = "ID",
                    TextField = "ModelName",
                    FilterField = "ID",
                    OrderBy = "ModelName"
                },
                "INVENTORYSTATUS" => new DropdownConfig
                {
                    TableName = "InventoryStatus",
                    ValueField = "ID",
                    TextField = "StatusName",
                    FilterField = "ID",
                    OrderBy = "StatusName"
                },
                "VEHICLESTATUS" => new DropdownConfig
                {
                    TableName = "VehicleStatus",
                    ValueField = "ID",
                    TextField = "StatusName",
                    FilterField = "ID",
                    OrderBy = "StatusName"
                },
                "INSDESTINATION" => new DropdownConfig
                {
                    TableName = "INS_DestionationMaster",
                    ValueField = "ID",
                    TextField = "DestinationName",
                    FilterField = "ID",
                    OrderBy = "DestinationName"
                },
                "INSORGANIZATION" => new DropdownConfig
                {
                    TableName = "INS_Organization",
                    ValueField = "ID",
                    TextField = "OrganizationName",
                    FilterField = "ID",
                    OrderBy = "OrganizationName"
                },
                "INSSTATUS" => new DropdownConfig
                {
                    TableName = "INSStatus",
                    ValueField = "ID",
                    TextField = "StatusName",
                    FilterField = "ID",
                    OrderBy = "StatusName"
                },
                "USER" => new DropdownConfig
                {
                    TableName = "Users",
                    ValueField = "ID",
                    TextField = "UserName",
                    FilterField = "ID",
                    OrderBy = "UserName"
                },
                "MAINMENU" => new DropdownConfig
                {
                    TableName = "MainMenus",
                    ValueField = "MainMenuId",
                    TextField = "MainMenuName",
                    FilterField = "MainMenuId",
                    OrderBy = "MainMenuName"
                },
                "WEIGHTUNIT" => new DropdownConfig
                {
                    TableName = "WeightUnit",
                    ValueField = "ID",
                    TextField = "UnitCode",
                    FilterField = "ID",
                    OrderBy = "UnitCode"
                },


                _ => throw new Exception("Invalid dropdown key")
            };
        }
    }
}
