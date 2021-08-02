using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaishinPlusSampleForCSharp.Common
{
    class ClassUtil
    {
        public static string ConvertToDateTime(string param)
        {
            int paramInt = Int32.Parse(param);
            string paramString = "";
            string retString = "";

            if (param.Length <= 4)
            {
                paramString = paramInt.ToString("0000");
                retString = paramString.Insert(2, ":");
            }
            else if (param.Length <= 6)
            {
                paramString = paramInt.ToString("000000");
                retString = paramString.Insert(2, ":");
                retString = retString.Insert(5, ":");
            }
            else if (param.Length <= 8)
            {
                paramString = paramInt.ToString("00000000");
                retString = paramString.Insert(4, "-");
                retString = retString.Insert(7, "-");
            }

            return retString;
        }
    }

    interface FormRoot
    {
        void ChangedStockCode(string code, string name);
    }

    interface FormOrder
    {
        void ChangedStockQuote(string price);
    }

    interface FormTrade
    {
        void ReceivedStockTrade();
    }

    interface FormMonitor
    {
        void SetSTGInfo(String stgID, String stgName);
    }
}
