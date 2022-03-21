using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.EmailMessageBuilder
{
    public class CommonTools
    {
        private const string ActionIdFormat = "yyyyMMddHHmmssfff";

        public static void SetCommonFieldForCreate<T>(T dataModel)
        {
            Type type = dataModel.GetType();
            DateTime currTime = DateTime.Now;
            type.GetProperty("UpdateUser").SetValue(dataModel, 0);
            type.GetProperty("UpdateDate").SetValue(dataModel, currTime);
            type.GetProperty("CreateUser").SetValue(dataModel, 0);
            type.GetProperty("CreateDate").SetValue(dataModel, currTime);
            type.GetProperty("ActionId").SetValue(dataModel, currTime.ToString(ActionIdFormat));
        }

        public static void SetCommonFieldForUpdate<T>(T dataModel)
        {
            Type type = dataModel.GetType();
            DateTime currTime = DateTime.Now;
            type.GetProperty("UpdateUser").SetValue(dataModel, 0);
            type.GetProperty("UpdateDate").SetValue(dataModel, currTime);
            type.GetProperty("ActionId").SetValue(dataModel, currTime.ToString(ActionIdFormat));
        }
    }
}
