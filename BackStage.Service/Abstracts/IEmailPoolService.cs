using System.Collections.Generic;
using BackStage.Service.Dto;

namespace BackStage.Service.Abstracts
{
    public partial interface IEmailPoolService
    {
        /// <summary>
        /// 获取指定数量的待发送邮件
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        List<EmailPoolDto> GetWithReceivers(int top);
    }
}
