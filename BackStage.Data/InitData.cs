/*******************************************************************************
* Copyright (C) opcomunity.com
* 
* Author: dj.wong
* Create Date: 09/04/2015 11:47:14
* Description: Automated building by service@opcomunity.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/
using System.Data.Entity;

namespace BackStage.Data
{
    /// <summary>
    /// 初始化数据
    /// </summary>
    public static class InitData
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BackStageContext, Configuration>());
        }
    }
}
