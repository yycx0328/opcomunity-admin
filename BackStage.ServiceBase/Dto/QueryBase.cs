/*******************************************************************************
* Copyright (C) opcomunity.com
* 
* Author: dj.wong service@opcomunity.com 
* Create Date: 2015/8/6 9:27:09
* Description: Automated building by service@opcomunity.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

namespace BackStage.ServiceBasis.Dto
{
    /// <summary>
    /// 基础查询类
    /// </summary>
    public class QueryBase
    {
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 开始记录数
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 次数
        /// </summary>
        public int Draw { get; set; }
    }
}
