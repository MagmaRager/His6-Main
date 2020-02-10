using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using His.MedicalInsurance.Entity;
using His.MedicalInsurance.Client;

namespace His6.Base
{
    public class MedHelper
    {
        static MedHelper()
        {
            /// <param name="orgCode">医疗机构代码</param>
            /// <param name="clientId">终端代码</param>

            YBComponent.InitYBComponent("", "");
        }

        /// <summary>
        /// 医保芯片卡获取卡号
        /// </summary>
        /// <returns></returns>
        public static string GetCardNo()
        {
            var value = YBComponent.ReadCardNo(null);

            //null TBC
            Entity_SHYBZHB info = value[1] as Entity_SHYBZHB;

            string cardNo = info.ybkh == null ? info.kh : info.ybkh;
            return cardNo;
        }

        /// <summary>
        ///获取卡类型、卡信息
        public static CardInfo GetCardInfo(string CardNo)
        {
            CardNo = CardNo.Trim();
            CardInfo info = new CardInfo();

            //白玉兰卡
            if (CardNo.Length == 10 || CardNo.Length == 28)
            {
                info.CardData = CardNo.Substring(0, 10);
                info.CardType = CardTypeEnum.YiBaoCiTiaoKa;
                info.ClassName = CardClassEnum.YiBaoCiTiaoKa;
                info.ORIGINALDATA = CardNo;
            }
            //芯片卡  异地
            else if (CardNo.Length == 9 || (CardNo.Length == 16 && CardNo.Contains("_")))
            {
                info.CardData = CardNo;
                info.CardType = CardTypeEnum.YiBaoXinPianKa;
                info.ClassName = CardClassEnum.YiBaoXinPianKa;
                info.ORIGINALDATA = CardNo.Substring(0, 9);
            }
            //自费卡
            else
            {
                info.CardData = CardNo;
                info.CardType = CardTypeEnum.ZiFeiKa;
                info.ClassName = CardClassEnum.ZiFeiKa;
                info.ORIGINALDATA = CardNo;
            }

            return info;
        }
    }
}
