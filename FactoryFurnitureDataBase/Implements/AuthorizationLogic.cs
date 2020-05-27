using System;
using System.Collections.Generic;
using System.Text;
using FactoryFurnitureDataBase.Models;
using System.Linq;
using DocumentFormat.OpenXml.Spreadsheet;

namespace FactoryFurnitureDataBase.Implements
{
    public class AuthorizationLogic
    {
        public bool Input(Staff model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {

                var staff = context.Staffs.FirstOrDefault(c => c.Identification_Number == model.Identification_Number);
                if (staff == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
